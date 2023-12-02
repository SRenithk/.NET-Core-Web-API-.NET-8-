using E_Commerce.Domain.Models;
using E_Commerce.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task Update(Category category);
    }
}
