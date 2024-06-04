using AutoMapper;
using MultiShop.Catalog.Dtos.CategoryDto;
using MultiShop.Catalog.Dtos.ProductDetailDto;
using MultiShop.Catalog.Dtos.ProductDto;
using MultiShop.Catalog.Dtos.ProductImageDto;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
           CreateMap<Category, ResultCategoryDto>().ReverseMap();
           CreateMap<Category, UpdateCategoryDto>().ReverseMap();
           CreateMap<Category, CreateCategoryDto>().ReverseMap();
           CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();



        }
    }
}
