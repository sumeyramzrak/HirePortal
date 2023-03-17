using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;


namespace Hireportal.Data.Management.Commands
{
    internal class EditLookupCommand : IRequestHandler<EditLookupRequest, bool>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public EditLookupCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(EditLookupRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<LookUp>();
            var entity = await repository.Get(f => f.Id == request.Data.Id, cancellationToken);
            if (entity is null)
            {
                return false;
            }
            var mapped = mapper.Map(request.Data, entity);
            repository.Update(mapped);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}
