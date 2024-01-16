namespace SOLID.App.SOLID.DIP;

internal interface IProductService
{
    List<Product> GetList();
}

internal class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public List<Product> GetList()
    {
        return _productRepository.GetList();
    }
}