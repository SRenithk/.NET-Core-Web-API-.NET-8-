using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task UpdateAsync(Product product)
        {
            _dbcontext.Update(product);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
