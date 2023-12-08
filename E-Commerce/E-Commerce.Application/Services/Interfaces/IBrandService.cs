using E_Commerce.Application.DTO.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllAsync();
        Task<BrandDto> GetByIdAsync(int id);
        Task<CreateBrandDto> CreateAsync(CreateBrandDto createBrandDto);
        Task UpdateAsync(BrandDto brandDto);
        Task DeleteAsync(int id);
    }
}
