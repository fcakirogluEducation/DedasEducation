﻿using DedasApp.API.Models.ProductModels;

namespace DedasApp.API.Models.Repositories
{
    public class ProductRepositoryWithSqlServer : IProductRepository
    {
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product productToDelete)
        {
            throw new NotImplementedException();
        }

        public Product? GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}