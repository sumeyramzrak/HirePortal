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
    internal class LookupTypeService : ILookupTypeService
    {
        private readonly IMediator mediator;

        public LookupTypeService(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public Task<bool> CreateLookupType(NewLookupTypeRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new NewLookupTypeRequest(data), cancellationToken);
        }

        public Task<List<LookupTypeDto>> GetAll(CancellationToken cancellationToken)
        {
            return mediator.Send(new LookupTypeListRequest(), cancellationToken);
        }

        public Task<bool> LookupTypeDeleteById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new DeleteLookupTypeByIdRequest(id), cancellationToken);
        }

        public Task<LookupTypeDto> LookupTypeGetById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new GetLookupTypeByIdRequest(id), cancellationToken);
        }

        public Task<bool> UpdateLookUpType(EditLookupTypeRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new EditLookupTypeRequest(data), cancellationToken);
        }
    }
}
