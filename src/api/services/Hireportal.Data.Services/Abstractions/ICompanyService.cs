using Hireportal.Data.Request.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Services.Abstractions
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<CompanyDto>> GetAll(CancellationToken cancellationToken);
        Task<bool> UpdateCompany(EditCompanyRequestDto data, CancellationToken cancellationToken);
        Task<bool> CreateCompany(NewCompanyRequestDto data, CancellationToken cancellationToken);
        Task<bool> DeleteCompanyById(Guid id, CancellationToken cancellationToken);

    }
}
