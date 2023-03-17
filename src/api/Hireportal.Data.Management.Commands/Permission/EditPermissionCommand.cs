using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.CompanyManager;
using MediatR;


namespace Hireportal.Data.Management.Commands
{
    internal class EditPermissionCommand : IRequestHandler<EditPermissionRequest, bool>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public EditPermissionCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(EditPermissionRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Permission>();
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
