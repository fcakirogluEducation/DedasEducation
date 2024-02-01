using DedasApp.API.Models.ProductModels;

namespace DedasApp.API.Models.Services
{
    public interface IProductService
    {
        Response<List<ProductDto>> GetAll();
        Response<Product?> Get(int id);
        Response<ProductCreateResponseDto> Save(ProductCreateRequestDto product);
        void Update(ProductUpdateRequestDto product);
        void Delete(int id);
    }
}