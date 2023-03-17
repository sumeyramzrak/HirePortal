using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;
namespace Hireportal.Data.Management.Commands
{
    internal class NewSystemParameterCommand : IRequestHandler<NewSystemParameterRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewSystemParameterCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(NewSystemParameterRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Data.Value) || string.IsNullOrEmpty(request.Data.Key))
            {
                return false;
            }
            var repository = unitOfWork.GetRepository<SystemParameter>();
            var response=await repository.Get(f=>!f.IsDeleted && f.Key == request.Data.Key, cancellationToken);
            if (response == null)
            {
                return false;
            }
            var entity=mapper.Map<SystemParameter>(request.Data);
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}
