using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hireportal.Data.Services.Abstractions;
using Hireportal.Data.Request.Contracts;

namespace Hireportal.Api.Controllers.Management
{

    [Route("api/management/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Authorize(Roles = "0,1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] NewUserRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.CreateUser(data, cancellationToken);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var result = await service.GetUsers(cancellationToken);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.GetUserById(id, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await service.DeleteUserById(id, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] EditUserRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.UpdateUser(data, cancellationToken);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
