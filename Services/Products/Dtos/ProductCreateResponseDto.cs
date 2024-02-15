namespace Services.Products.Dtos;

public class ProductCreateResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Created { get; set; } = default!;
}