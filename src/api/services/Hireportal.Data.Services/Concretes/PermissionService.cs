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
    internal class PermissionService : IPermissionService
    {
        private readonly IMediator mediator;

        public PermissionService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<bool> CreatePermission(NewPermissionRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new NewPermissionRequest(data), cancellationToken);
        }

        public Task<bool> DeletePermissionById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new DeletePermissionByIdRequest(id), cancellationToken);
        }

        public Task<List<PermissionDto>> GetAll(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetPermissionRequest(), cancellationToken);
        }
        public Task<PermissionDto> GetByIdPermission(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new GetPermissionByIdRequest(id), cancellationToken);
        }

        public Task<bool> UpdatePermission(EditPermissionRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new EditPermissionRequest(data), cancellationToken);
        }
    }
}
