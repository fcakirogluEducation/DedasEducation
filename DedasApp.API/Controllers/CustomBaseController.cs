using System.Net;
using DedasApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DedasApp.API.Controllers;

public class CustomBaseController : ControllerBase
{
    public IActionResult CreateResult<T>(Response<T> response)
    {
        if (response.StatusCode == HttpStatusCode.NoContent)
            return new ObjectResult(null) { StatusCode = (int)response.StatusCode };

        return new ObjectResult(response)
        {
            StatusCode = (int)response.StatusCode
        };
    }
}