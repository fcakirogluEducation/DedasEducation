using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcept.Abstraction
{
    #region Interface Example

    public class Run
    {
        public void Method1()
        {
            var productService = new ProductService(new ProductRepositoryWithOracle());
            var product = new Product();
            productService.SaveProduct(product);
        }
    }


    public class ProductService
    {
        private IProductRepositoryWithOnlyUpdate _productRepository;

        public ProductService(IProductRepositoryWithOnlyUpdate productRepository)
        {
            _productRepository = productRepository;
        }

        public void SaveProduct(Product newProduct)
        {
            //validation
            _productRepository.Update(newProduct);
        }
    }


    public class Product
    {
        public int Id { get; set; }
    }

    public interface IProductRepository
    {
        Product Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product GetById(int id);
        List<Product> GetAll();


        public int CalculateKdv(int price)
        {
            return price * 18 / 100;
        }
    }

    public interface IProductRepositoryRead
    {
        Product GetById(int id);
        List<Product> GetAll();
    }

    public interface IProductRepositoryWrite
    {
        Product Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }

    public interface IProductRepositoryWithOnlyUpdate
    {
        void Update(Product product);
    }

    public class ProductRepositoryWithSqlServer : IProductRepositoryRead, IProductRepositoryWrite,
        IProductRepositoryWithOnlyUpdate
    {
        public string Kdv { get; set; }

        public void Method1()
        {
        }

        public Product Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }


    public class ProductRepositoryWithOracle : IProductRepositoryRead, IProductRepositoryWrite,
        IProductRepositoryWithOnlyUpdate
    {
        public Product Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }

    #endregion


    //diamond problem
}