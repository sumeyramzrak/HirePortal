using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class RegisterUserRequest : IRequest<bool>
    {
        public RegisterUserRequest(RegisterUserRequestDto data)
        {
            Data = data;
        }

        public RegisterUserRequestDto Data { get; }
    }
}
