using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class EditLookupRequest : IRequest<bool>
    {

        public EditLookupRequest(EditLookupRequestDto data)
        {
            Data = data;
        }

        public EditLookupRequestDto Data { get; }
    }

}
