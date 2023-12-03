using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.Services.Interfaces;
using E_Commerce.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<CategoryDto> CreateAsync(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
