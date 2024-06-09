﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDto;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;  
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = _categoryService.GetAll();
            return Ok(values);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdCategory(string id)
        {
            var values = _categoryService.GetByIdCategoryAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori başarıyla eklendi.");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
           await _categoryService.DeleteCategoryAsync(id);
            return Ok("Başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Başarıyla güncellendi.");
        }
       


    }
}
