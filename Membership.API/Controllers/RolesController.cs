using Membership.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(RoleManager<AppRole> roleManager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var role = new AppRole
            {
                Name = roleName
            };

            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(role.Id);
        }
    }
}