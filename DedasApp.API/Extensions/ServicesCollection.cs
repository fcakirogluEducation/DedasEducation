using DedasApp.API.Models.Products;
using DedasApp.API.Models.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace DedasApp.API.Extensions;

public static class ServicesCollection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<NotFoundFilterAttribute>();
        services.AddScoped<IProductService, ProductService>();
        services.AddValidatorsFromAssemblyContaining<Program>();
        services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true);

        return services;
    }
}