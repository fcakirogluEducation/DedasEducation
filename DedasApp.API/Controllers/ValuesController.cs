using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DedasApp.API.Controllers
{
    /// <summary>
    /// GET  https://localhost:5000/api/values
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [NonAction]
        public int Calculate()
        {
            return 5;
        }


        [HttpGet]
        public string HelloWorld()
        {
            return "Hello world";
        }

        // endpoint
        //[HttpGet]
        //public int Sum(int a, int b)
        //{
        //    return a + b;
        //}
    }
}