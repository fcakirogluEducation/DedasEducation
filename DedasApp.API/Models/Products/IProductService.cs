using DedasApp.API.Models.ProductModels;

namespace DedasApp.API.Models.Services;

public interface IProductService
{
    Response<List<ProductDto>> GetAll();
    Response<Product?> Get(int id);
    Response<ProductCreateResponseDto> Save(ProductCreateRequestDto product);
    Response<string> Update(ProductUpdateRequestDto product);
    Response<string> Delete(int id);
}