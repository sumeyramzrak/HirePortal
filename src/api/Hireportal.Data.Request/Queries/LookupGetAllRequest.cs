using Hireportal.Data.Request.Contracts;
using MediatR;

namespace Hireportal.Data.Request.Queries
{
    public class LookupGetAllRequest : IRequest<List<LookUpDto>>
    {
    }
}
