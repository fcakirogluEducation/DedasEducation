using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repositories.Categories;
using Repositories.ManyToMany;
using Repositories.ProductFeatures;
using Repositories.Products;

namespace Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor contextAccessor)
    : DbContext(options)
{
    public DbSet<Teacher> Teachers { get; set; } = default!;

    public DbSet<Student> Students { get; set; } = default!;

    public DbSet<Product> Products { get; set; } = default!;

    public DbSet<Category> Categories { get; set; } = default!;

    public DbSet<ProductFeature> ProductFeatures { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SaveChangesInterceptor(contextAccessor)).UseLazyLoadingProxies()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }


    //public override int SaveChanges()
    //{
    //    var context = contextAccessor.HttpContext;
    //    var userId = context?.User.FindFirstValue(ClaimTypes.NameIdentifier);

    //    userId ??= "10";


    //    var entities = ChangeTracker.Entries().ToList();
    //    foreach (var entry in entities)
    //    {
    //        if (entry.Entity is BaseEntity baseEntity)
    //        {
    //            switch (entry.State)
    //            {
    //                case EntityState.Added:

    //                    Entry(baseEntity).Property(x => x.Updated).IsModified = false;
    //                    Entry(baseEntity).Property(x => x.UpdatedByUser).IsModified = false;
    //                    baseEntity.Created = DateTime.Now;
    //                    baseEntity.CreatedByUser = Convert.ToInt32(userId);

    //                    break;
    //                case EntityState.Modified:
    //                    Entry(baseEntity).Property(x => x.Created).IsModified = false;
    //                    Entry(baseEntity).Property(x => x.CreatedByUser).IsModified = false;
    //                    baseEntity.UpdatedByUser = Convert.ToInt32(userId);
    //                    baseEntity.Updated = DateTime.Now;

    //                    break;
    //            }
    //        }
    //    }


    //    return base.SaveChanges();
    //}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}