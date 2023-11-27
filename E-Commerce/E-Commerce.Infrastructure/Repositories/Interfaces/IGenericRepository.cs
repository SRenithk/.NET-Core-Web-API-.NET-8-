using E_Commerce.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Expression<Func<T,bool>> condition);

        Task<T> CreateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
