using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Contracts
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public string DisplayName { get; set; }
        public Common.UserType UserType { get; set; }

    }
}
