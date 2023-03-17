namespace Hireportal.Entites.CompanyManager
{
    [Table("Expenditures",Schema= "Activites")]
    public class Expenditure:EntityBase
    {
        [Required]
        [MaxLength(32)]
        public Guid CompanyUserId { get; set; }

        [Required]
        [MaxLength(32)]
        public Guid? LookUpTypeId { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public byte[] File { get; set; }

        public bool IsApproved { get; set; }

        [Required]
        [MaxLength(32)]
        public Guid ManagerID { get; set; }

        [Required]
        public DateTime ApprovedDate { get; set; }

        [ForeignKey(nameof(CompanyUserId))]
        public CompanyUser CompanyUser { get; set; }

        [ForeignKey(nameof(LookUpTypeId))]
        public LookUpType LookUpType { get; set; }
    }
}
