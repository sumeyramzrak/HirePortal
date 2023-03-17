using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Entites.Profile
{
    [Table("Companies", Schema = "Profile")]
    public class Company : EntityBase
    {
        [Required]
        [MaxLength(32)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(64)]
        public string CompanyDescription { get; set; }

        [Required]
        [MaxLength(64)]
        public string MembershipPlan { get; set; }

        [Required]
        [MaxLength(64)]
        public string MembershipStartDate { get; set; }

        [Required]
        [MaxLength(64)]
        public string MembershipEndDate { get; set; }

        [MaxLength(64)]
        public string Comment { get; set; }

        [Required]
        [MaxLength(64)]
        public string SupportEmail { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
