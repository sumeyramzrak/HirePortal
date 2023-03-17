using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Hireportal.Api.Controllers.Public
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "0, 1")]
    public class CompanyUserController : ControllerBase
    {
        private readonly ICompanyUserService service;

        public CompanyUserController(ICompanyUserService service)
        {
            this.service = service;
        }

        [HttpGet("list/{id}")]
        public async Task<IActionResult> GetCompanyUser(Guid id,CancellationToken cancellationToken)
        {
            var result = await service.GetAll(id,cancellationToken);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCompanyUserById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.DeleteCompanyUserById(id, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> EditCompanyUser([FromBody] EditCompanyUserRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.UpdateCompanyUser(data, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] NewCompanyUserRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.CreateCompanyUser(data, cancellationToken);
            return Ok(result);
        }
        //TODO:Tamamlanıcak
    }
}
