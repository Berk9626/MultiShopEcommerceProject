using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscounCouponList()
        {
            var values = await _discountService.GetAllCouponAsync();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscounCouponById(int id)
        {
            var values = await _discountService.GetByIdCouponAsync(id);
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscounCouponAsync(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon succcessfully added!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscounCouponAsync(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("successfully deleted!!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto)
        {
            await  _discountService.UpdatdeCouponDto(updateCouponDto);
            return Ok("Updated successfully!");


        }



    }
}
