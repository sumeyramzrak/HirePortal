using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hireportal.Api.Controllers.Management
{
    [Route("api/management/[controller]")]
    [ApiController]
    [Authorize(Roles = "0")]
    public class SystemParameterController:ControllerBase
    {
        private readonly ISystemParameterService service;

        public SystemParameterController(ISystemParameterService service)
        {
            this.service = service;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody]NewSystemParameterRequestDto data,CancellationToken cancellationToken)
        {
            var result=await service.CreateSystemParameter(data,cancellationToken);
            return Ok(result);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetSystemParameterById([FromRoute]Guid id,CancellationToken cancellationToken)
        {
            var result=await service.GetSystemParameterById(id,cancellationToken);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSystemParameterById([FromRoute]Guid id,CancellationToken cancellationToken)
        {
            var result=await service.DeleteSystemParameterById(id,cancellationToken);
            return Ok(result);
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetAllSystemParameters(CancellationToken cancellationToken)
        {
            var result = await service.GetAll(cancellationToken);
            return Ok(result);
        }
    }
}
