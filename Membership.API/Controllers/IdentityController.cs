using Membership.API.Models;
using Membership.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IdentityService identityService) : ControllerBase
    {
        [HttpPost("SignIn")]
        public async Task<IActionResult> SigIn(SigninDto signinDto)
        {
            var (isSuccess, result) = await identityService.Signin(signinDto);
            if (!isSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}