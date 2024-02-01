using DedasApp.API.Models;
using DedasApp.API.Models.Repositories;
using DedasApp.API.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DI Container (Dependency Injection) / IoC Container (Inversion of Control) Framework

// Asp.Net API=> Autfact,Ninject,
//Dependency Inverson / Inversion of Control => Dependency Injection(Design Pattern)


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Flow
// Singleton > Scoped > Transient kullanamazs?n.
// Transient> Scoped> Singleton  kullanabilirsin.


//Singleton
// Helper
builder.Services.AddSingleton<UrlHelper>();

//Scoped
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddKeyedScoped<IProductRepository, ProductRepositoryWithInMemory>("in-memory");
builder.Services.AddKeyedScoped<IProductRepository, ProductRepositoryWithSqlServer>("sqlserver");
//Transient

var app = builder.Build();

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