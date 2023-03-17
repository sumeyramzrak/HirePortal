using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;
namespace Hireportal.Data.Management.Queries
{
    internal class GetLookupTypeListQuery : IRequestHandler<LookupTypeListRequest, List<LookupTypeDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetLookupTypeListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<List<LookupTypeDto>> Handle(LookupTypeListRequest request, CancellationToken cancellationToken)
        {
            var repository=unitOfWork.GetRepository<LookUpType>();
            return repository.GetAll<LookupTypeDto>(u=>!u.IsDeleted,u=>u.Name,cancellationToken);
        }
    }
}
