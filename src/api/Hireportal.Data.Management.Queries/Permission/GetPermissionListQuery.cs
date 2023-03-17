using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.CompanyManager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Management.Queries
{
    internal class GetPermissionListQuery : IRequestHandler<GetPermissionRequest, List<PermissionDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetPermissionListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<List<PermissionDto>> Handle(GetPermissionRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Permission>();
            return repository.GetAll<PermissionDto>(o => !o.IsDeleted, o => o.Id, cancellationToken);
        }
    }
}
