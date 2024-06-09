using MultiShop.Catalog.Dtos.ProductDetailDto;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<ResultProductDetailDto> GetAll();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
