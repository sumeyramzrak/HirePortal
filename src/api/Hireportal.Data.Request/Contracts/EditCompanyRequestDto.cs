using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Contracts
{
    public class EditCompanyRequestDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string MembershipPlan { get; set; }
        public string MembershipStartDate { get; set; }
        public string MembershipEndDate { get; set; }
        public string Comment { get; set; }
        public string SupportEmail { get; set; }
    }
}
