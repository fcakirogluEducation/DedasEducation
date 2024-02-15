using Microsoft.AspNetCore.Mvc.Filters;

namespace DedasApp.API.Filters;

public class MyResultFilter : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        Console.WriteLine("Result Executing");
    }

    public override void OnResultExecuted(ResultExecutedContext context)
    {
        Console.WriteLine("Result Executed");
    }
}