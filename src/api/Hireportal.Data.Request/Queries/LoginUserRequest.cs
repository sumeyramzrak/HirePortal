using Hireportal.Data.Request.Contracts;
using MediatR;
namespace Hireportal.Data.Request.Queries
{
    public class LoginUserRequest : IRequest<LoginResultDto>
    {
        public LoginUserRequest(LoginRequestDto data)
        {
            Data = data;
        }

        public LoginRequestDto Data { get; }
    }
}
