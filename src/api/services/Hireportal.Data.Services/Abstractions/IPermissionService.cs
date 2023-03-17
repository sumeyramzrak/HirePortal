using Hireportal.Data.Request.Contracts;

namespace Hireportal.Data.Services.Abstractions
{
    public interface IPermissionService
    {
        Task<List<PermissionDto>> GetAll(CancellationToken cancellationToken);
        Task<bool> CreatePermission(NewPermissionRequestDto data, CancellationToken cancellationToken);
        Task<bool> UpdatePermission(EditPermissionRequestDto data, CancellationToken cancellationToken);
        Task<PermissionDto> GetByIdPermission(Guid id, CancellationToken cancellationToken);
       Task<bool> DeletePermissionById(Guid id, CancellationToken cancellationToken);
    }
}
