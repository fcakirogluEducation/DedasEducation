using Microsoft.EntityFrameworkCore;

namespace Repositories.Products;

public class ProductRepositoryWithSqlServer(AppDbContext context) : IProductRepository
{
    public IReadOnlyList<Product> GetAll()
    {
        // business store procedure
        return context.Products.AsNoTracking().ToList().AsReadOnly();
    }

    public Product? GetById(int id)
    {
        var product = context.Products.First(x => x.Id == id);

        //var state = context.Entry(product).State;


        //product.Name = "kalem 1";


        //context.Products.Update(product);
        //context.SaveChanges();


        //var state2 = context.Entry(product).State;
        return product;
    }

    public void Create(Product product)
    {
        var state = context.Entry(product).State;


        context.Entry(product).State = EntityState.Added;
        // context.Products.Add(product); // change tracker ?

        var state2 = context.Entry(product).State;


        context.SaveChanges();
    }

    public void Update(Product product)
    {
        // context.Entry(product).State = EntityState.Modified;
        context.Products.Update(product);
        context.SaveChanges();
    }

    public void Delete(Product productToDelete)
    {
        //context.Entry(productToDelete).State = EntityState.Deleted;
        context.Products.Remove(productToDelete);

        context.SaveChanges();
    }

    public Product? GetByName(string name)
    {
        return context.Products.FirstOrDefault(x => x.Name == name);
    }
}