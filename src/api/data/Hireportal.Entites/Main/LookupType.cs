namespace Hireportal.Entites.Main
{
    [Table("LookUpTypes", Schema = "Main")]
    public class LookUpType : EntityBase
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
