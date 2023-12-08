using E_Commerce.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<CreateProductDto> CreateAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(int id);
    }
}
