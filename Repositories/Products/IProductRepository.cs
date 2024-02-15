﻿namespace Repositories.Products;

public interface IProductRepository
{
    IReadOnlyList<Product> GetAll();
    Product? GetById(int id);
    void Create(Product product);
    void Update(Product product);
    void Delete(Product productToDelete);

    Product? GetByName(string name);
}