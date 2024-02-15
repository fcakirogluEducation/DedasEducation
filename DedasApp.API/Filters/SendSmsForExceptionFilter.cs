using Microsoft.AspNetCore.Mvc.Filters;

namespace DedasApp.API.Filters;

public class SendSmsForExceptionFilter : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        Console.WriteLine("Hata sms'si gönderildi");
    }
}