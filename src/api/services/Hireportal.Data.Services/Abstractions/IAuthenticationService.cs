using Hireportal.Data.Request.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterUser(RegisterUserRequestDto data, CancellationToken cancellationToken);
        Task<LoginResultDto> LoginUser(LoginRequestDto data, CancellationToken cancellationToken);
    }
}
