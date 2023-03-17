using Hireportal.Data.Request.Contracts;
using MediatR;

namespace Hireportal.Data.Request.Queries
{
    public class GetPermissionByIdRequest : IRequest<PermissionDto>
    {
        public GetPermissionByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

