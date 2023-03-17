using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Contracts
{
    public class NewCompanyUserRequestDto
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
