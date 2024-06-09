using MultiShop.Catalog.Dtos.ProductImageDto;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageServices
    {
        Task<ResultProductImageDto> GetAll();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
