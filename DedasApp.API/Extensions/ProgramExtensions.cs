using System.Net;
using DedasApp.API.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DedasApp.API.Extensions;

public static class ProgramExtensions
{
    public static int Multiply(this int number)
    {
        return number * 2;
    }

    public static IServiceCollection AddBehaviorConfigure(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(o => { o.SuppressModelStateInvalidFilter = true; });
        return services;
    }

    public static void UseCustomExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(x =>
        {
            x.Run(context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                if (exception is not null)
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";


                    return context.Response.WriteAsJsonAsync(Response<string>.Fail(exception.Message,
                        HttpStatusCode.InternalServerError));
                }

                return Task.CompletedTask;
            });
        });
    }
}