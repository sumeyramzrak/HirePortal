using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class NewCompanyRequest : IRequest<bool>
    {
        public NewCompanyRequest(NewCompanyRequestDto data)
        {
            Data = data;
        }

        public NewCompanyRequestDto Data { get; }
    }
}
