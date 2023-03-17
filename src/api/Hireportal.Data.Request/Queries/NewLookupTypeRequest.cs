using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class NewLookupTypeRequest : IRequest<bool>
    {
        public NewLookupTypeRequest(NewLookupTypeRequestDto data)
        {
            Data = data;
        }
        public NewLookupTypeRequestDto Data { get; set; }
    }
}
