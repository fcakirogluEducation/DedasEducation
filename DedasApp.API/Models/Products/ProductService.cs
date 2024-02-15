using System.Net;
using DedasApp.API.Models.ProductModels;
using DedasApp.API.Models.Repositories;

namespace DedasApp.API.Models.Services;

public class ProductService([FromKeyedServices("in-memory")] IProductRepository _productRepository)
    : IProductService
{
    public Response<List<ProductDto>> GetAll()
    {
        var product = _productRepository.GetAll();


        var productListDto = product.Select(x => new ProductDto
        {
            Created = x.Created,
            Id = x.Id,
            Name = x.Name,
            Price = x.Price
        }).ToList();


        return Response<List<ProductDto>>.Success(productListDto, HttpStatusCode.OK);
    }

    public Response<Product?> Get(int id)
    {
        var hasProduct = _productRepository.GetById(id);

        if (hasProduct is null) return Response<Product?>.Fail("Product not found", HttpStatusCode.NotFound);


        return Response<Product?>.Success(hasProduct, HttpStatusCode.OK);
    }

    public Response<ProductCreateResponseDto> Save(ProductCreateRequestDto request)
    {
        var newProduct = new Product
        {
            Id = new Random().Next(1, 10000),
            Name = request.Name!,
            Price = request.Price!.Value,
            Barcode = "abc",
            Created = DateTime.Now
        };


        _productRepository.Create(newProduct);
        var productResponseDto = new ProductCreateResponseDto
        {
            Id = newProduct.Id,
            Created = newProduct.Created.ToShortDateString(),
            Name = newProduct.Name,
            Price = newProduct.Price
        };

        return Response<ProductCreateResponseDto>.Success(productResponseDto, HttpStatusCode.Created);
    }


    public Response<string> Update(ProductUpdateRequestDto request)
    {
        var hasProduct = _productRepository.GetById(request.Id);

        if (hasProduct is null) return Response<string>.Fail("Güncellenecek ürün bulunamadı.", HttpStatusCode.NotFound);

        hasProduct.Name = request.Name;
        hasProduct.Price = request.Price;


        _productRepository.Update(hasProduct);

        return Response<string>.Success(string.Empty, HttpStatusCode.NoContent);
    }

    public Response<string> Delete(int id)
    {
        var hasProduct = _productRepository.GetById(id);

        if (hasProduct is null) return Response<string>.Fail("Silinecek ürün bulunamadı.", HttpStatusCode.NotFound);

        _productRepository.Delete(hasProduct);
        return Response<string>.Success(string.Empty, HttpStatusCode.NoContent);
    }
}