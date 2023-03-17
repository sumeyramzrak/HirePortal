using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Entites.CompanyManager
{
    [Table("Debits", Schema = "Activites")]
    public class Debit : EntityBase
    {
        [Required]
        [MaxLength(32)]
        public Guid? CompanyUserId { get; set; }
        [Required]
        [MaxLength(32)]
        public Guid? LookUpTypeId { get; set; }
        [Required]
        [MaxLength(32)]
        public string DebitName { get; set; }
        [Required]
        [MaxLength(32)]
        public string Description { get; set; }

        [Required] 
        public DateTime DueDate { get; set; }

        public bool IsApproved { get; set; }

        public string InformationNote { get; set; }

        [ForeignKey(nameof(CompanyUserId))]
        public CompanyUser CompanyUser { get; set; }

        [ForeignKey(nameof(LookUpTypeId))]
        public LookUpType LookUpType { get; set; }
    }
}
