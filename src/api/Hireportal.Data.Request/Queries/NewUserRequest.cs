using Hireportal.Data.Request.Contracts;
using MediatR;

namespace Hireportal.Data.Request.Queries
{
    public class NewUserRequest:IRequest<bool>
    {
        public NewUserRequest(NewUserRequestDto data)
        {
            Data = data;
        }

        public NewUserRequestDto Data { get; }
    }
}
