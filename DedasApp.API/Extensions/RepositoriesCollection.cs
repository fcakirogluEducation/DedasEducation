using DedasApp.API.Consts;
using DedasApp.API.Models.Repositories;

namespace DedasApp.API.Extensions;

public static class RepositoriesCollection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddKeyedScoped<IProductRepository, ProductRepositoryWithInMemory>(RepositoryConst.InMemory);
        services.AddKeyedScoped<IProductRepository, ProductRepositoryWithSqlServer>(RepositoryConst.SqlServer);

        return services;
    }
}