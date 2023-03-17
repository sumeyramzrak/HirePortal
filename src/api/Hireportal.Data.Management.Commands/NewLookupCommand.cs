using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;


namespace Hireportal.Data.Management.Commands
{
    internal class NewLookupCommand : IRequestHandler<NewLookupRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewLookupCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(NewLookupRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Data.Name))
            {
                return false;
            }
            var repository = unitOfWork.GetRepository<LookUp>();
            var conflict = await repository.Get(f => !f.IsDeleted && f.Name == request.Data.Name, cancellationToken);
            if (conflict is not null)
            {
                return false;
            }
            var entity = mapper.Map<LookUp>(request.Data);
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }

    }
}
