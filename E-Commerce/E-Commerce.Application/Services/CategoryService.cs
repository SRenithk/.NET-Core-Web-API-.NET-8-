using AutoMapper;
using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.Services.Interfaces;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Models;
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
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CreateCategoryDto> CreateAsync(CreateCategoryDto createCategoryDto) //due to CreateCategoryDto type the return must be same
        {
            var convertedEntity = _mapper.Map<Category>(createCategoryDto); //converted DTO to original model
            var entity = await _categoryRepository.CreateAsync(convertedEntity);
            return _mapper.Map<CreateCategoryDto>(entity); //converted back after creation
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var entities = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(entities);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            var convertedEntity = _mapper.Map<Category>(categoryDto); //convert to original then update
            await _categoryRepository.Update(convertedEntity);
        }
    }
}
