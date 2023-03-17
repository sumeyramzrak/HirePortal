using Hireportal.Data.Request.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Services.Abstractions
{
    public interface ICompanyUserService
    {
        Task<List<CompanyUserDto>> GetAll(Guid id,CancellationToken cancellationToken);
        Task<bool> UpdateCompanyUser(EditCompanyUserRequestDto data, CancellationToken cancellationToken);
        Task<bool> CreateCompanyUser(NewCompanyUserRequestDto data, CancellationToken cancellationToken);
        Task<bool> DeleteCompanyUserById(Guid id, CancellationToken cancellationToken);
    }
}
