using AutoMapper;
using E_Commerce.Application.DTO.Brand;
using E_Commerce.Application.DTO.Category;
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


        }
    }
}
