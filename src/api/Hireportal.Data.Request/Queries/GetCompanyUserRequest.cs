using Hireportal.Data.Request.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Queries
{
    public class GetCompanyUserRequest : IRequest<List<CompanyUserDto>>
    {
        public GetCompanyUserRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
