using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class DeleteLookUpByIdRequest : IRequest<bool>
    {
        public DeleteLookUpByIdRequest(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
