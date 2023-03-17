using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class EditCompanyUserRequest : IRequest<bool>
    {
        public EditCompanyUserRequest(EditCompanyUserRequestDto data)
        {
            Data = data;
        }

        public EditCompanyUserRequestDto Data { get; }
    }
}
