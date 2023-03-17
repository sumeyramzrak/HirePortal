using Hireportal.Data.Request.Contracts;
using MediatR;

namespace Hireportal.Data.Request.Queries
{

    public class EditPermissionRequest : IRequest<bool>
    {
        public EditPermissionRequest(EditPermissionRequestDto data)
        {
            Data = data;
        }

        public EditPermissionRequestDto Data { get; }
    }
}
