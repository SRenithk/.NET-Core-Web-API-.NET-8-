using E_Commerce.Domain.Contracts;
using E_Commerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection; //manual install from NuGet Package Manager
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection  AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IBrandRepository,BrandRepository>();
            return services;
        }
    }
}
