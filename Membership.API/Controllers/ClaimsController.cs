using System.Globalization;
using System.Security.Claims;
using Membership.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController(UserManager<AppUser> userManager) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUserClaim()
        {
            var user = await userManager.FindByEmailAsync("mehmet@outlook.com");


            await userManager.AddClaimAsync(user!,
                new Claim("birthDate", new DateTime(2005, 1, 1).ToString(CultureInfo.InvariantCulture)));


            return Ok();
        }
    }
}