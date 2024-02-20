using System.ComponentModel.DataAnnotations.Schema;
using Repositories.Categories;
using Repositories.ProductFeatures;

namespace Repositories.Products;

//[Table("ProductsTB")]
public class Product
{
    //[Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;


    //[Column(name: "PriceMoney", TypeName = "decimal(18,2)")]
    //[Precision(18, 2)]
    public decimal Price { get; set; }

    public DateTime Created { get; set; }

    public string Barcode { get; set; } = null!;


    //[ForeignKey("Category")]
    public int CategoryId { get; set; }


    public Category Category { get; set; } = default!;

    public ProductFeature? ProductFeature { get; set; }
}