using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class NewCompanyUserRequest : IRequest<bool>
    {
        public NewCompanyUserRequest(NewCompanyUserRequestDto data)
        {
            Data = data;
        }

        public NewCompanyUserRequestDto Data { get; }
    }
}
