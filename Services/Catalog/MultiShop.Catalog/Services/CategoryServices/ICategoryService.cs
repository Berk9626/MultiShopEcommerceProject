using MultiShop.Catalog.Dtos.CategoryDto;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService //kategorilerle ilgili işlemlerin imzaları
    {
        Task<List<ResultCategoryDto>> GetAll();
        Task CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto categoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
