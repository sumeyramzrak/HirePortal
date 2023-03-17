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
    internal class GetCompanyListQuery : IRequestHandler<GetCompanyRequest, List<CompanyDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCompanyListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<List<CompanyDto>> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Company>();
            return repository.GetAll<CompanyDto>(o =>!o.IsDeleted, o => o.CompanyName, cancellationToken);
        }
    }
}
