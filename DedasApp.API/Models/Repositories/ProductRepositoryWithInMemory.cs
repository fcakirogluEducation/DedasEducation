﻿using DedasApp.API.Models.ProductModels;

namespace DedasApp.API.Models.Repositories
{
    public class ProductRepositoryWithInMemory : IProductRepository
    {
        private static readonly List<Product> Products;

        static ProductRepositoryWithInMemory()
        {
            Products =
            [
                new() { Id = 1, Name = "Kalem 1", Created = DateTime.Now, Price = 100 },
                new() { Id = 2, Name = "Kalem 1", Created = DateTime.Now, Price = 100 }
            ];
        }

        public List<Product> GetAll()
        {
            return Products;
        }

        public Product? GetById(int id)
        {
            //LinQ
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Product product)
        {
            Products.Add(product);
        }

        public void Update(Product product)
        {
            var productForIndex = Products.FindIndex(x => x.Id == product.Id);
            Products[productForIndex].Name = product.Name;
            Products[productForIndex].Price = product.Price;
        }

        public void Delete(int id)
        {
            var productToDelete = GetById(id);

            Products.Remove(productToDelete!);
        }
    }
}