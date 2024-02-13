using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DedasApp.API.Filters
{
    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["timer"] = Stopwatch.StartNew();
            Console.WriteLine("Action Executing");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var sw = context.HttpContext.Items["timer"] as Stopwatch;
            Console.WriteLine($"Method Çalışma süresi:{sw!.ElapsedMilliseconds}");

            Console.WriteLine("Action Executed");
        }
    }
}