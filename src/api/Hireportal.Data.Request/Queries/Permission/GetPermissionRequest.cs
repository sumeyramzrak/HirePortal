using Hireportal.Data.Request.Contracts;
using MediatR;

namespace Hireportal.Data.Request.Queries
{
    public class GetPermissionRequest : IRequest<List<PermissionDto>>
    {
    }
}
