using MultiShop.Catalog.Dtos.ProductDto;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<ResultProductDto> GetAll();
        Task CreateProductAsync(CreateProductDto createproductDto);
        Task UpdateProductAsync(UpdateProductDto updateproductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
