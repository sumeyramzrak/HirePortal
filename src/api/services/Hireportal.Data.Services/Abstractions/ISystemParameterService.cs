using Hireportal.Data.Request.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Services.Abstractions
{
    public interface ISystemParameterService
    {
        Task<bool> CreateSystemParameter(NewSystemParameterRequestDto data, CancellationToken cancellationToken);
        Task<SystemParameterDto> GetSystemParameterById(Guid id, CancellationToken cancellationToken);
        Task<bool> DeleteSystemParameterById(Guid id, CancellationToken cancellationToken);
        Task<List<SystemParameterDto>> GetAll(CancellationToken cancellationToken);
    }
}
