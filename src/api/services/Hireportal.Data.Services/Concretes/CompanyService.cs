using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Data.Services.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Services.Concretes
{
    internal class CompanyService : ICompanyService
    {
        private readonly IMediator mediator;

        public CompanyService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<bool> CreateCompany(NewCompanyRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new NewCompanyRequest(data), cancellationToken);
        }

        public Task<bool> DeleteCompanyById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new DeleteCompanyByIdRequest(id), cancellationToken);
        }

        public Task<List<CompanyDto>> GetAll(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetCompanyRequest(), cancellationToken);
        }

        public Task<CompanyDto> GetById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new GetCompanyByIdRequest(id), cancellationToken);
        }

        public Task<bool> UpdateCompany(EditCompanyRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new EditCompanyRequest(data), cancellationToken);
        }
    }
}
