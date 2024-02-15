using System.Net;
using DedasApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DedasApp.API.Filters;

public class ValidationFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid) return;


        var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList();

        context.Result = new BadRequestObjectResult(Response<string>.Fail(errors, HttpStatusCode.BadRequest));


        base.OnActionExecuting(context);
    }
}