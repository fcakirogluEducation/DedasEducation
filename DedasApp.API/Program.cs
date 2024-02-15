using DedasApp.API.Extensions;
using DedasApp.API.Filters;
using DedasApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddBehaviorConfigure().AddControllers(x => x.Filters.Add<ValidationFilterAttribute>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices().AddRepositories();

var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseMiddleware<WhiteListIpMiddleware>();

#region Örnek middleware

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("1. middleware request\n");
//    // Do work that doesn't write to the Response.
//    // Request
//    await next();
//    await context.Response.WriteAsync("1. middleware response\n");
//    // Response
//});

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("2. middleware request\n");
//    // Do work that doesn't write to the Response.
//    // Request
//    await next();
//    await context.Response.WriteAsync("2. middleware response\n");
//    // Response
//});

//app.Map("/ornek",
//    app => { app.Run(async (context) => { await context.Response.WriteAsync("terminal middleware\n"); }); });


//app.MapWhen(context => context.Request.Query.ContainsKey("version"),
//    app => { app.Run(async (context) => { await context.Response.WriteAsync("terminal middleware\n"); }); });

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();