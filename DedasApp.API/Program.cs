using DedasApp.API.Consts;
using DedasApp.API.Filters;
using DedasApp.API.Models;
using DedasApp.API.Models.Repositories;
using DedasApp.API.Models.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<NotFoundFilterAttribute>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddKeyedScoped<IProductRepository, ProductRepositoryWithInMemory>(RepositoryConst.InMemory);
builder.Services.AddKeyedScoped<IProductRepository, ProductRepositoryWithSqlServer>(RepositoryConst.SqlServer);

builder.Services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true);

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
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