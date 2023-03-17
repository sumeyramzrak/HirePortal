using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Common
{
    public interface IClaims
    {
        bool IsAuthenticated { get; set; }
        public CurrentUser CurrentUser { get; set; }
    }
}
