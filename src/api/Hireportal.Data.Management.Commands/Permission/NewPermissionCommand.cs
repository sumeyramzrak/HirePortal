using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.CompanyManager;
using MediatR;

namespace Hireportal.Data.Management.Commands
{
    internal class NewPermissionCommand : IRequestHandler<NewPermissionRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewPermissionCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(NewPermissionRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Permission>();
            var conflict = await repository.Get(f => !f.IsDeleted , cancellationToken);
            if (conflict is not null)
            {
                return false;
            }
            var entity = mapper.Map<Permission>(request.Data);
            entity.IsApproved = false; // default olarak onaylanmamış olsun
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}

