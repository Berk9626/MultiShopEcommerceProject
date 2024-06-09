using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDto;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    public class ProductImageController: ControllerBase
    {
        private readonly IProductImageServices _ProductImageService;
        public ProductImageController(IProductImageServices ProductImageService)
        {
            _ProductImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = _ProductImageService.GetAll();
            return Ok(values);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdProductImage(string id)
        {
            var values = _ProductImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _ProductImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("ProductImage başarıyla eklendi.");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _ProductImageService.DeleteProductImageAsync(id);
            return Ok("Başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Başarıyla güncellendi.");
        }
    }
}
