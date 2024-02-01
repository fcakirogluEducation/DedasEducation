using DedasApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DedasApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDataController : ControllerBase
    {
        // query strings
        [HttpGet]
        public int QueryData([FromQuery] int a, [FromQuery] int b)
        {
            return a + b;
        }


        [HttpGet("{a}/{b}")]
        public int RouteData([FromRoute] int a, [FromRoute] int b)
        {
            return a + b;
        }

        [Route("HeaderData")]
        [HttpGet]
        public int HeaderData([FromHeader] int a, [FromHeader] int b)
        {
            return a + b;
        }

        [HttpPost]
        public int BodyData(ProductRouteData product) // complex types
        {
            return product.Id;
        }


        [HttpPut]
        public int BodyDataByHeader(ProductRouteData product) // complex types
        {
            return product.Id;
        }
    }
}