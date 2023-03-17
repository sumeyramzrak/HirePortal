using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Entites.CompanyManager
{
    [Table("Shifts", Schema = "Activites")]
    public class Shift:EntityBase
    {
        [Required]
        [MaxLength(32)]
        public Guid CompanyUserId { get; set; }
        [Required]
        [MaxLength(32)]
        public Guid? LookUpTypeId { get; set; }

        [Required]
        public DateTime ShiftDay { get; set; }

        [Required]
        public int TotalHour { get; set; }

        public string Break1 { get; set; }

        public string LunchBreak { get; set; }

        public string Break2 { get; set; }

        public int TotalBreak { get; set; }

        public int TotalWorkHour { get; set; }

        [ForeignKey(nameof(CompanyUserId))]
        public CompanyUser CompanyUser { get; set; }
        [ForeignKey(nameof(LookUpTypeId))]
        public LookUpType LookUpType { get; set; }
    }
}
