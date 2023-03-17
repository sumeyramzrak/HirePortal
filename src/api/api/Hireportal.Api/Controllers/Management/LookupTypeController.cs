using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hireportal.Api.Controllers.Management
{
    [Route("api/management/[controller]")]
    [ApiController]
    [Authorize(Roles = "0")]
    public class LookupTypeController : ControllerBase
    {
        private readonly ILookupTypeService service;

        public LookupTypeController(ILookupTypeService service)
        {
            this.service = service;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] NewLookupTypeRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.CreateLookupType(data, cancellationToken);
            return Ok(result);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.LookupTypeGetById(id, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> LookupTypeDeleteById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.LookupTypeDeleteById(id, cancellationToken);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> EditLookUpType([FromBody] EditLookupTypeRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.UpdateLookUpType(data, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetLookupTypes(CancellationToken cancellationToken)
        {
            var result = await service.GetAll(cancellationToken);
            return Ok(result);
        }
    }
}
