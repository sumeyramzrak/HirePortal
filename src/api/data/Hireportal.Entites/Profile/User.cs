using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Entites.Profile
{
    [Table("Users", Schema = "Profile")]
    public class User : EntityBase
    {
        [MaxLength(64)]
        [Required]
        public string UserName { get; set; }
        [MaxLength(64)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(64)]
        public string Email { get; set; }
        [MaxLength(64)]
        public string Department { get; set; }
        [MaxLength(64)]
        public string Address { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(64)]
        public string Position { get; set; }
        [Required]
        [MaxLength(64)]
        public string Password { get; set; }
        [MaxLength(36)]
        public string VerificationId { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
