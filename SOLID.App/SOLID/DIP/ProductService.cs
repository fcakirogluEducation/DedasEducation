namespace SOLID.App.SOLID.DIP;

internal interface IProductService
{
    List<Product> GetList();
}

internal class ProductService(IProductRepository productRepository) : IProductService
{
    public List<Product> GetList()
    {
        return productRepository.GetList();
    }

    public void ChangeRepository(IProductRepository repository)
    {
        productRepository = repository;
    }
}