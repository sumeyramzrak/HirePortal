using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Entites.CompanyManager
{
    [Table("Permissions", Schema = "Activites")]
    public class Permission : EntityBase
    {
        [Required]
        [MaxLength(32)]
        public Guid? CompanyUserId { get; set; }

        [Required]
        [MaxLength(32)]
        public Guid? LookUpId { get; set; }

        [Required]
        [MaxLength(32)]
        public Guid? LookUpTypeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public double PermissionDayCount { get; set; }

        public bool IsApproved { get; set; }

        [Required]
        [MaxLength(32)]
        public Guid ApprovedManagerID { get; set; }

        [Required]
        public DateTime ApprovedDate { get; set; }

        //ınfo eklendi - migration çıkılacak

        [Required]
        [MaxLength(128)]
        public string Information { get; set; }

        [ForeignKey(nameof(CompanyUserId))]
        public CompanyUser CompanyUser { get; set; }

        [ForeignKey(nameof(LookUpId))]
        public LookUp LookUp { get; set; }

        [ForeignKey(nameof(LookUpTypeId))]
        public LookUpType LookUpType { get; set; }

    }
}
