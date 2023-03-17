using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;

namespace Hireportal.Data.Management.Queries
{
    internal class GetLookupListQuery : IRequestHandler<LookupGetAllRequest, List<LookUpDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetLookupListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<List<LookUpDto>> Handle(LookupGetAllRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<LookUp>();
            return repository.GetAll<LookUpDto>(u => !u.IsDeleted, u => u.Name, cancellationToken);
        }
    }
}