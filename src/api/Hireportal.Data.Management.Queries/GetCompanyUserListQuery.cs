using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Profile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Management.Queries
{
    internal class GetCompanyUserListQuery : IRequestHandler<GetCompanyUserRequest, List<CompanyUserDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCompanyUserListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<List<CompanyUserDto>> Handle(GetCompanyUserRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<CompanyUser>();
            return repository.GetAll<CompanyUserDto>(f => true, o => o.UserId, cancellationToken);
        }
    }
}
