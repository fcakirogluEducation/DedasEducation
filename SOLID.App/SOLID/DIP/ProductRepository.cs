namespace SOLID.App.SOLID.DIP;

internal interface IProductRepository
{
    List<Product> GetList();
}

internal class ProductRepositoryWithOracle : IProductRepository
{
    public List<Product> GetList()
    {
        return
        [
            new Product { Id = 1, Name = "Oracle Product 1", Price = 10.00m },
            new Product { Id = 2, Name = "Oracle Product 2", Price = 20.00m }
        ];
    }
}

internal class ProductRepository : IProductRepository
{
    public List<Product> GetList()
    {
        return
        [
            new Product { Id = 1, Name = "Product 1", Price = 10.00m },
            new Product { Id = 2, Name = "Product 2", Price = 20.00m }
        ];
    }
}