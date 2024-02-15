using Microsoft.AspNetCore.Mvc.Filters;

namespace DedasApp.API.Filters;

public class LoggingActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var firstArg = context.ActionArguments.FirstOrDefault();

        if (firstArg.Value is not null)
            if (int.TryParse(firstArg.Value.ToString(), out var id))
                Console.WriteLine($"Gelen değer :{id}");


        Console.Write("Method Çalışmadan önce loglama yapılacak");
        base.OnActionExecuting(context);
    }
}