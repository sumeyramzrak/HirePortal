using Hireportal.Data.Request.Contracts;
using MediatR;
namespace Hireportal.Data.Request.Queries
{

    public class GetUserRequest : IRequest<List<UserListDto>>
    {
    }
}
