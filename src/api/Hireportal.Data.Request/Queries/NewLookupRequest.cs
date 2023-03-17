using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class NewLookupRequest : IRequest<bool>
    {
        public NewLookupRequest(NewLookupRequestDto data)
        {
            Data = data;
        }

        public NewLookupRequestDto Data { get; }
    }
}
