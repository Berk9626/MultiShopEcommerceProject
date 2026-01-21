using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        Task UpdatdeCouponDto(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
    }
}
