using E_Commerce.Application.Common;
using E_Commerce.Application.Services;
using E_Commerce.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
