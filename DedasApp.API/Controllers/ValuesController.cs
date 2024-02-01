using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DedasApp.API.Controllers
{
    /// <summary>
    /// GET  https://localhost:5000/api/values
    /// </summary>
    [Route("api/[controller]")] // attribute based routing
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [NonAction]
        private int Calculate()
        {
            return 5;
        }


        [HttpGet]
        public string GetAll()
        {
            return $"get all";
        }

        //// https://localhost:5000/api/values?id=1 // querystrings
        //// https://localhost:5000/api/values/1 // route data parameters
        [HttpGet("{id}")]
        public string GetById(int id) //
        {
            return $"get by id {id}";
        }


        [HttpGet("{page}/{pageSize}")]
        public string GetAllWithPaged(int page, int pageSize) //
        {
            return $"get all {page} - {pageSize}";
        }

        [Route("GetAllWithPaged/{page}")]
        [HttpGet]
        public string GetAllWithPaged(int page) //
        {
            return $"GetAllWithPaged {page}";
        }


        [HttpPost]
        public string Save()
        {
            return "save";
        }


        [HttpPut]
        public string Update()
        {
            return "save";
        }

        [HttpDelete]
        public string Delete()
        {
            return "save";
        }
    }
}