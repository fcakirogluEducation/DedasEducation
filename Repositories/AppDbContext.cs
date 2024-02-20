using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Repositories.Categories;
using Repositories.ManyToMany;
using Repositories.ProductFeatures;
using Repositories.Products;

namespace Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Teacher> Teachers { get; set; } = default!;

    public DbSet<Student> Students { get; set; } = default!;

    public DbSet<Product> Products { get; set; } = default!;

    public DbSet<Category> Categories { get; set; } = default!;

    public DbSet<ProductFeature> ProductFeatures { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}