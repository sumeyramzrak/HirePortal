using Hireportal.Data.Request.Contracts;
using MediatR;

namespace Hireportal.Data.Request.Queries
{
    public class NewPermissionRequest : IRequest<bool>
    {
        public NewPermissionRequest(NewPermissionRequestDto data)
        {
            Data = data;
        }

        public NewPermissionRequestDto Data { get; }
    }
}
