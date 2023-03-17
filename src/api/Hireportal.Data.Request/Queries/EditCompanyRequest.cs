using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class EditCompanyRequest : IRequest<bool>
    {
        public EditCompanyRequest(EditCompanyRequestDto data)
        {
            Data = data;
        }

        public EditCompanyRequestDto Data { get; }
    }
}
