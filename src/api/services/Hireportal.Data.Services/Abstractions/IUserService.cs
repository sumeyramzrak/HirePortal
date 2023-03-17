using Hireportal.Data.Request.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserListDto>> GetUsers(CancellationToken cancellationToken);
        Task<UserListDto> GetUserById(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateUser(EditUserRequestDto data, CancellationToken cancellationToken);
        Task<bool> DeleteUserById(Guid id, CancellationToken cancellationToken);
        Task<bool> CreateUser(NewUserRequestDto data, CancellationToken cancellationToken);
    }
    
}