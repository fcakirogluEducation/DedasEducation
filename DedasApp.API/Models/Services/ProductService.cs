using DedasApp.API.Models.ProductModels;
using DedasApp.API.Models.Repositories;

namespace DedasApp.API.Models.Services
{
    public class ProductService([FromKeyedServices("in-memory")] IProductRepository _productRepository)
        : IProductService
    {
        public Response<List<ProductDto>> GetAll()
        {
            var product = _productRepository.GetAll();


            var productListDto = product.Select(x => new ProductDto()
            {
                Created = x.Created,
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToList();


            return new Response<List<ProductDto>>() { Data = productListDto };
        }

        public Response<Product?> Get(int id)
        {
            var hasproduct = _productRepository.GetById(id);

            return new Response<Product?>() { Data = hasproduct };
        }

        public Response<ProductCreateResponseDto> Save(ProductCreateRequestDto request)
        {
            var newProduct = new Product()
            {
                Id = new Random().Next(1, 10000),
                Name = request.Name!,
                Price = request.Price!.Value,
                Barcode = "abc",
                Created = DateTime.Now
            };


            _productRepository.Create(newProduct);
            var productResponseDto = new ProductCreateResponseDto()
            {
                Id = newProduct.Id,
                Created = newProduct.Created.ToShortDateString(),
                Name = newProduct.Name,
                Price = newProduct.Price
            };
            return new Response<ProductCreateResponseDto>() { Data = productResponseDto };
        }


        public void Update(ProductUpdateRequestDto request)
        {
            var hasProduct = _productRepository.GetById(request.Id);

            if (hasProduct is null)
            {
                throw new Exception("Product not found");
            }

            hasProduct.Name = request.Name;
            hasProduct.Price = request.Price;


            _productRepository.Update(hasProduct);
        }

        public void Delete(int id)
        {
            var hasProduct = _productRepository.GetById(id);

            if (hasProduct is null)
            {
                throw new Exception("Product not found");
            }

            _productRepository.Delete(hasProduct);
        }
    }
}