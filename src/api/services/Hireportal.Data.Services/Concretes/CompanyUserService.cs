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
    internal class CompanyUserService : ICompanyUserService
    {
        private readonly IMediator mediator;

        public CompanyUserService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<bool> CreateCompanyUser(NewCompanyUserRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new NewCompanyUserRequest(data), cancellationToken);
        }

        public Task<bool> DeleteCompanyUserById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new DeleteCompanyUserByIdRequest(id), cancellationToken);
        }

        public Task<List<CompanyUserDto>> GetAll(Guid id,CancellationToken cancellationToken)
        {
            return mediator.Send(new GetCompanyUserRequest(id), cancellationToken);
        }

        public Task<bool> UpdateCompanyUser(EditCompanyUserRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new EditCompanyUserRequest(data), cancellationToken);
        }
    }
}
