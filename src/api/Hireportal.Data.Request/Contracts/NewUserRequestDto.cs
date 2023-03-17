using Hireportal.Common;

namespace Hireportal.Data.Request.Contracts
{
    public class NewUserRequestDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public UserType UserType { get; set; }
        public string Password { get; set; }
    }
}
