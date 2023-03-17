using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using MediatR;
using Hireportal.Entites.Profile;

namespace Hireportal.Data.Management.Commands
{
    internal class DeleteCompanyCommand : IRequestHandler<DeleteCompanyByIdRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCompanyCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Company>();
            var entity = await repository.Get(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);
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

