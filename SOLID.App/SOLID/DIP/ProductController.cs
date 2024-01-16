namespace SOLID.App.SOLID.DIP;

internal class ProductController(IProductService productService)
{
   

    public List<Product> GetList()
    {
        return productService.GetList();
    }
}