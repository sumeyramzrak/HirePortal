using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class EditUserRequest:IRequest<bool>
    {
        public EditUserRequest(EditUserRequestDto data)
        {
            Data = data;
        }

        public EditUserRequestDto Data { get; }
    }
}
