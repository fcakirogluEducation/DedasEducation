using System.Net;

namespace DedasApp.API.Middlewares;

// rate limit
public class WhiteListIpMiddleware(RequestDelegate next)
{
    private readonly List<IPAddress> _whiteIpList =
    [
        IPAddress.Parse("::1"), // IPV6  localhost
        IPAddress.Parse("127.0.0.1") // IPV4 localhost
    ];

    public async Task InvokeAsync(HttpContext context)
    {
        var reqIpAddress = context.Connection.RemoteIpAddress;


        if (!_whiteIpList.Contains(reqIpAddress!))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            await context.Response.WriteAsync("Forbidden");
            return;
        }


        //request

        await next(context);


        //response
    }
}