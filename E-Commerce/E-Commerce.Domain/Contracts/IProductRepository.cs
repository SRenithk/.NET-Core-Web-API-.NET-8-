using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task UpdateAsync(Product product);
    }
}
