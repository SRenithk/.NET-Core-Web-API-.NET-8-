using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository 
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task Update(Category category)
        {
            //var entity = await _dbcontext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            _dbcontext.Update(category);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
