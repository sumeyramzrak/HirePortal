using Hireportal.Data.Request.Contracts;

namespace Hireportal.Data.Services.Abstractions
{
    public interface ILookupService
    {
        Task<LookUpDto> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<LookUpDto>> GetAll(CancellationToken cancellationToken);
        Task<bool> UpdateLookUp(EditLookupRequestDto data, CancellationToken cancellationToken);
        Task<bool> CreateLookup(NewLookupRequestDto data, CancellationToken cancellationToken);
        Task<bool> DeleteLookUpById(Guid id, CancellationToken cancellationToken);

    }
}
