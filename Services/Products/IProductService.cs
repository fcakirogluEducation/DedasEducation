using Repositories.Products;
using Services.Products.Dtos;

namespace DedasApp.API.Models.Services;

public interface IProductService
{
    Response<List<ProductDto>> GetAll();

    // TODO : Refactoring ( Entity > DTO)
    Response<Product?> Get(int id);
    Response<ProductCreateResponseDto> Save(ProductCreateRequestDto product);
    Response<string> Update(ProductUpdateRequestDto product);
    Response<string> Delete(int id);
}