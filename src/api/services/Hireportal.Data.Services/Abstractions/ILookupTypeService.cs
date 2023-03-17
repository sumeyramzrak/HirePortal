using Hireportal.Data.Request.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Services.Abstractions
{
    public interface ILookupTypeService
    {
        Task<LookupTypeDto> LookupTypeGetById(Guid id, CancellationToken cancellationToken);
        Task<bool> LookupTypeDeleteById(Guid id, CancellationToken cancellationToken);
        Task<List<LookupTypeDto>> GetAll(CancellationToken cancellationToken);

        Task<bool> UpdateLookUpType(EditLookupTypeRequestDto data, CancellationToken cancellationToken);
        Task<bool> CreateLookupType(NewLookupTypeRequestDto data, CancellationToken cancellationToken);

    }
}
