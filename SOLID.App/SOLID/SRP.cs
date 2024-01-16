namespace SOLID.App.SOLID.SRP;

public class ProductRepository
{
    private List<Product> Products { get; } = new();


    public List<Product> GetProducts => Products;

    public void Add(Product product)
    {
        Products.Add(product);
    }

    public void Remove(Product product)
    {
        Products.Remove(product);
    }
}

public class ProductPresentation
{
    public void WriteToConsole(List<Product> products)
    {
        foreach (var product in products)
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
    }
}

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; } = default!;
    public decimal Price { get; set; }
}