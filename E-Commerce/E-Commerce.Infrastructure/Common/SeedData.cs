using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Common
{
    public class SeedData
    {
        public static async Task SeedDataAsync(ApplicationDbContext _dbContext)
        {
            if(!_dbContext.Brands.Any())
            {
                await _dbContext.AddRangeAsync(

                    new Brand
                    {
                        Name = "Apple",
                        EstablishedYear = 1956
                    },
                    new Brand
                    {
                        Name = "Samsung",
                        EstablishedYear = 1945
                    },
                    new Brand
                    {
                        Name = "Sony",
                        EstablishedYear = 1990
                    },
                    new Brand
                    {
                        Name = "Hp",
                        EstablishedYear = 1985
                    },
                    new Brand
                    {
                        Name = "Lenovo",
                        EstablishedYear = 1951
                    },
                    new Brand
                    {
                        Name = "Acer",
                        EstablishedYear = 1931
                    },
                    new Brand
                    {
                        Name = "LG",
                        EstablishedYear = 1928
                    },
                    new Brand
                    {
                        Name = "Vivo",
                        EstablishedYear = 1945
                    });
                await _dbContext.SaveChangesAsync();  
            }
        }
    }
}
