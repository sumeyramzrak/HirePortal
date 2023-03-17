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

    internal class LookupService : ILookupService
    {
        private readonly IMediator mediator;

        public LookupService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<bool> CreateLookup(NewLookupRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new NewLookupRequest(data), cancellationToken);
        }

        public Task<bool> DeleteLookUpById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new DeleteLookUpByIdRequest(id), cancellationToken);
        }

        public Task<bool> UpdateLookUp(EditLookupRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new EditLookupRequest(data), cancellationToken);
        }

        public Task<LookUpDto> GetById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new GetLookupByIdRequest(id), cancellationToken);
        }

        Task<List<LookUpDto>> ILookupService.GetAll(CancellationToken cancellationToken)
        {
            return mediator.Send(new LookupGetAllRequest(), cancellationToken);
        }
    }
}
