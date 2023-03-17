using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class NewSystemParameterRequest : IRequest<bool>
    {
        public NewSystemParameterRequest(NewSystemParameterRequestDto data)
        {
            Data = data;
        }

        public NewSystemParameterRequestDto Data { get; }
    }
}
