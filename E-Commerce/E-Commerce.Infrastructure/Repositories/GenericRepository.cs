using E_Commerce.Domain.Shared;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel

    {
        protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            //var category = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync<T>();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> condition)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(condition);
            
        }
    }
}
