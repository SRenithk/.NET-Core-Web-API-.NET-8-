using AutoMapper;
using E_Commerce.Application.DTO.Brand;
using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.DTO.Product;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Category
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            //Brand
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();

            //Product
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Category, opt => opt.MapFrom(source => source.Category.Name))  // To map the Category Name to Category object which set as Foreign Key, 
                .ForMember(x => x.Brand, opt => opt.MapFrom(source => source.Brand.Name));       //Additionally we need to Include in Repository and use in Service file

        }
    }
}
