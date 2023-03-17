using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;

namespace Hireportal.Data.Management.Commands
{
    internal class DeleteLookUpCommand : IRequestHandler<DeleteLookUpByIdRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteLookUpCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteLookUpByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<LookUp>();
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