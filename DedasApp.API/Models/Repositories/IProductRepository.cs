﻿using DedasApp.API.Models.ProductModels;

namespace DedasApp.API.Models.Repositories;

public interface IProductRepository
{
    IReadOnlyList<Product> GetAll();
    Product? GetById(int id);
    void Create(Product product);
    void Update(Product product);
    void Delete(Product productToDelete);

    Product? GetByName(string name);
}