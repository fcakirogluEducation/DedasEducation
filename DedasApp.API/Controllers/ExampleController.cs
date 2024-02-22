using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Categories;
using Repositories.ProductFeatures;
using Repositories.Products;

namespace DedasApp.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ExampleController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult Insert()
    {
        #region Bad way

        //var category = new Category() { Name = "Kalemler" };

        //context.Categories.Add(category);

        //context.SaveChanges();


        //var product = new Product()
        //    { Name = "Kalem 1", Price = 100, Barcode = "abc", Created = DateTime.Now, CategoryId = category.Id };

        //context.Products.Add(product);

        //context.SaveChanges(); 

        #endregion

        #region 2. Good Way

        var product = new Product { Name = "bardak1", Barcode = "abc", Created = DateTime.Now, Price = 200 };

        product.Category = new Category { Name = "bardaklar" };
        product.ProductFeature = new ProductFeature { Color = "red", Height = 100, Width = 200 };


        context.Products.Add(product);

        context.SaveChanges();

        #endregion

        #region 1. Good Way

        //var category = new Category() { Name = "Bantlar" };

        //var product = new Product()
        //{
        //    Name = "bant 1", Price = 100, Barcode = "abc", Created = DateTime.Now,
        //    ProductFeature = new() { Color = "red", Height = 100, Width = 200 }
        //};
        //var product2 = new Product() { Name = "bant 2", Price = 100, Barcode = "abc", Created = DateTime.Now };


        //category.Products = new List<Product>() { product, product2 };

        //context.Categories.Add(category);

        //context.SaveChanges(); 

        #endregion

        #region Many to Many

        //var student1 = new Student() { Name = "StudentA 1" };

        //var teacher1 = new Teacher() { Name = "TeacherA 1" };
        //var teacher2 = new Teacher() { Name = "TeacherA 2" };
        //student1.Teachers = new List<Teacher>() { teacher2, teacher1 };

        //context.Students.Add(student1);

        //context.SaveChanges(); 

        #endregion


        return Ok("Hello World");
    }


    [HttpGet]
    public IActionResult Update()
    {
        // bulk update

        // update product set price= price+100 where Id=2
        // context.Products.ExecuteUpdate(x => x.SetProperty(y => y.Price, z => z.Price + 100));
        context.Products.Where(x => x.Id == 2)
            .ExecuteUpdate(x => x
                .SetProperty(y => y.Price, z => z.Price + 500)
                .SetProperty(a => a.Name, b => b.Name + "4"));


        // 1.way
        //var product = context.Products.First(x => x.Id == 2);

        //product.Name = "Kalem 1111";

        //context.Products.Update(product);2

        //2.way


        // 2. way
        //var product = context.Products.First(x => x.Id == 2);

        //var productToUpdate = new { Id = 2, Name = "Kalem 3" };

        //change change-tracking kapalı
        //context.Entry(product).CurrentValues.SetValues(productToUpdate);

        //context.SaveChanges();


        return Ok("update");
    }


    [HttpDelete]
    public IActionResult Delete()
    {
        //bulk delete
        context.Products.Where(x => x.Id == 2).ExecuteDelete();

        // 1.way
        //var product = context.Products.First(x => x.Id == 2);

        //context.Products.Remove(product);

        //context.SaveChanges();

        return Ok("delete");
    }


    [HttpGet]
    public IActionResult Select()
    {
        var productSingle = context.Products.Single(x => x.Name == "kalem 1");
        var productFirst = context.Products.First(x => x.Name == "kalem 1");

        var products = context.Products.Where(p => (p.Name == "kalem 3" && p.Price == 300) || p.Barcode == "abc")
            .ToList();


        var products10 = context.Products.ToList().Where(x => x.Id > 5);

        var products11 = context.Products.Where(x => x.Id > 5).ToList();

        return Ok("select");
    }


    [HttpGet]
    public IActionResult RelatedDataLoad()
    {
        #region Eager Loading

        //var category = context.Categories
        //    .Include(x => x.Products)!
        //    .ThenInclude(x => x.ProductFeature)
        //    .First(x => x.Id == 3);


        //var products = context.Products
        //    .Include(x => x.Category)
        //    .Include(x => x.ProductFeature)
        //    .Where(x => x.Id > 5); 

        #endregion

        #region Explicit Loading

        //var category = context.Categories.First(x => x.Id == 2);

        //var product = context.Products.First();
        //if (true)
        //{
        //    // var products = context.Products.Where(x => x.CategoryId == category.Id).ToList();

        //    context.Entry(category).Collection(x => x.Products).Query().Where(x => x.Name.Contains("a")).Load();


        //    context.Entry(product).Reference(x => x.Category).Load();

        //    context.Entry(product).Reference(x => x.ProductFeature).Load();
        //} 

        #endregion


        var category = context.Categories.First();

        var categoryList = context.Categories.Include(x => x.Products).ToList();


        // N +1 ( 1 sorgu)


        foreach (var item in categoryList)
        {
            var products = item.Products;

            var i = 5;


            //// 1. yol
            //var products = context.Products.Where(x => x.CategoryId == item.Id).ToList();

            //// 2. yol ( explicit loading)
            //context.Entry(item).Collection(x => x.Products).Load();

            //decimal priceSum = 0;
            //item.Products.ForEach(x => { priceSum += x.Price; });
        }


        return Ok();
    }

    [HttpGet]
    public IActionResult RawSql()
    {
        var products = context.Products.FromSqlRaw("Select * from products").ToList();

        var price = 100;
        context.Database.ExecuteSqlRaw("Update products set price=price+{0}", price);


        context.Database.ExecuteSqlInterpolated($"Update products set price=price+{price}");
        return Ok(products);
    }


    [HttpGet]
    public IActionResult Join()
    {
        var products = (from p in context.Products
                join c in context.Categories on p.CategoryId equals c.Id
                join pf in context.ProductFeatures on p.Id equals pf.ProductId
                select new ProductSingleModel
                {
                    Name = p.Name,
                    Width = pf.Width,
                    CategoryName = c.Name
                }
            ).ToList();

        foreach (var item in products)
        {
        }


        var productListWithCategory = context.Products
            .Join(context.Categories, p => p.CategoryId, c => c.Id, (product, category) => new ProductSingleModel
            {
                Name = product.Name,
                CategoryName = category.Name
            }).ToList();


        return Ok();
    }


    [HttpGet]
    public IActionResult Transaciton()
    {
        using var transaction = context.Database.BeginTransaction();


        //10
        var category = new Category { Name = "Kalemler" };

        context.Categories.Add(category);

        context.SaveChanges();


        var product = new Product
            { Name = "Kalem 1", Price = 100, Barcode = "abc", Created = DateTime.Now, CategoryId = category.Id };


        context.Products.Add(product);

        context.SaveChanges();


        transaction.Commit();


        return Ok();
    }


    [HttpPost]
    public IActionResult DynamicWhere(ProductQueryRequestDto productQuery)
    {
        var productListQuery = context.Products.AsQueryable();


        if (!string.IsNullOrEmpty(productQuery.Name))
            productListQuery = productListQuery.Where(x => x.Name == productQuery.Name);

        if (productQuery.Price is not null && productQuery.Price > 0)
            productListQuery = productListQuery.Where(x => x.Price == productQuery.Price);

        if (!string.IsNullOrEmpty(productQuery.Barcode))
            productListQuery = productListQuery.Where(x => x.Barcode == productQuery.Barcode);


        var products = productListQuery.ToList();

        return Ok(products);
    }
}

public class ProductQueryRequestDto
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Barcode { get; set; }
}

public class ProductSingleModel
{
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public int Width { get; set; }
}