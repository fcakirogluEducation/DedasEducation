namespace DedasApp.API.Models.ProductModels
{
    public class ProductCreateRequestDto
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}