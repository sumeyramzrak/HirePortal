using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Entites.CompanyManager
{
    [Table("Payrolls", Schema = "Activites")]
    public class PayRoll : EntityBase
    {
        [Required]
        [MaxLength(32)]
        public string Period { get; set; }

        [Required]
        [MaxLength(32)]
        public Guid CompanyUserId { get; set; }
        [Required]
        [MaxLength(32)]
        public Guid? LookUpTypeId { get; set; }

        [Required]
        public decimal BaseSalary { get; set; }

        [Required]
        public decimal TotalTax { get; set; }

        [Required]
        public decimal Bounty { get; set; }

        [Required]
        public decimal NetSalary { get; set; }

        [ForeignKey(nameof(CompanyUserId))]
        public CompanyUser CompanyUser { get; set; }
        [ForeignKey(nameof(LookUpTypeId))]
        public LookUpType LookUpType { get; set; }
    }
}
