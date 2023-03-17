using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class EditLookupTypeRequest : IRequest<bool>
    {

        public EditLookupTypeRequest(EditLookupTypeRequestDto data)
        {
            Data = data;
        }

        public EditLookupTypeRequestDto Data { get; }
    }
}
