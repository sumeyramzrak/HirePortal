using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.CompanyManager;
using MediatR;

namespace Hireportal.Data.Management.Commands
{
    internal class DeletePermissionCommand : IRequestHandler<DeletePermissionByIdRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeletePermissionCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeletePermissionByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Permission>();
            var entity = await repository.Get(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                return false;
            }
            repository.Delete(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}
