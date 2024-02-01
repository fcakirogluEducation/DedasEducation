namespace DedasApp.API.Models.ProductModels
{
    public class ProductUpdateRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}