namespace DedasApp.API.Models.ProductModels;

//Entity
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime Created { get; set; }

    public string Barcode { get; set; } = null!;
}