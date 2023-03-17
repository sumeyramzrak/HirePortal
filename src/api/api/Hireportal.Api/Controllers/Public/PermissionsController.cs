using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Hireportal.Api.Controllers.Public
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService service;

        public PermissionsController(IPermissionService service)
        {
            this.service = service;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetPermissions(CancellationToken cancellationToken)
        {
            var result = await service.GetAll(cancellationToken);
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] NewPermissionRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.CreatePermission(data, cancellationToken);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> EditPermission([FromBody] EditPermissionRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.UpdatePermission(data, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("get/{id}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdPermission(id, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCompanyById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.DeletePermissionById(id, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
  
    }
}
