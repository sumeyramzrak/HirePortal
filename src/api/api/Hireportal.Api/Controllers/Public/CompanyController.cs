using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Hireportal.Api.Controllers.Public
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles="0")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService service;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] NewCompanyRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.CreateCompany(data, cancellationToken);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.GetById(id, cancellationToken);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCompany(CancellationToken cancellationToken)
        {
            var result = await service.GetAll(cancellationToken);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCompanyById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.DeleteCompanyById(id, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> EditCompany([FromBody] EditCompanyRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.UpdateCompany(data, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
