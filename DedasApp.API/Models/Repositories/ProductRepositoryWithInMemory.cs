using DedasApp.API.Models.ProductModels;

namespace DedasApp.API.Models.Repositories;

public class ProductRepositoryWithInMemory : IProductRepository
{
    private static readonly List<Product> Products;

    static ProductRepositoryWithInMemory()
    {
        Products =
        [
            new Product { Id = 1, Name = "Kalem 1", Created = DateTime.Now, Price = 100 },
            new Product { Id = 2, Name = "Kalem 1", Created = DateTime.Now, Price = 100 }
        ];
    }

    public IReadOnlyList<Product> GetAll()
    {
        return Products.AsReadOnly();
    }

    public Product? GetById(int id)
    {
        //LinQ
        return Products.FirstOrDefault(p => p.Id == id);
    }

    public void Create(Product product)
    {
        Products.Add(product);
    }

    public void Update(Product product)
    {
        var productForIndex = Products.FindIndex(x => x.Id == product.Id);
        Products[productForIndex].Name = product.Name;
        Products[productForIndex].Price = product.Price;
    }

    public void Delete(Product productToDelete)
    {
        Products.Remove(productToDelete!);
    }

    public Product? GetByName(string name)
    {
        return Products.FirstOrDefault(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }
}