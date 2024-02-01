using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DedasApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTypesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(int a, int b)
        {
            var sum = a + b;


            return Ok();
            return BadRequest();
            return Created();
            return NoContent();
            return new OkResult();
            return new OkObjectResult(sum);
            return new CreatedResult();

            return new BadRequestObjectResult(sum);
        }
    }
}