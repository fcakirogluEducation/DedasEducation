using DedasApp.API.Models.Services;

namespace DedasApp.API.Models
{
    public class UrlHelper
    {
        // Singleton
        private readonly IServiceProvider _serviceProvider;

        public UrlHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static string GetProductUrl(int id)
        {
            return $"https://localhost:5001/api/products/{id}";
        }

        public string GetBaseUrlFromDb()
        {
            using var scope = _serviceProvider.CreateScope();
            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

            return "";
        }
    }
}