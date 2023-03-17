using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Entites.Profile
{
    [Table("CompanyUsers", Schema = "Profile")]
    public class CompanyUser:EntityBase
    {
        public Guid? UserId { get; set; }
        public Guid? CompanyId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

    }
}
