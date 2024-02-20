using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositories.ProductFeatures;

namespace Repositories.Products;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductId);


        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);


        builder.Property(x => x.Price).HasPrecision(18, 2);
        //builder.ToTable("ProductTB");
        //builder.HasKey(x => x.Id);
        //builder.Property(x => x.Name).IsRequired().HasMaxLength(100)
        //    .HasColumnName("productprice");
    }
}