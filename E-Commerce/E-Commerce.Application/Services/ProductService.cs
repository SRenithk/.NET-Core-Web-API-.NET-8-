using AutoMapper;
using E_Commerce.Application.DTO.Product;
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
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService //primary constructor
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<CreateProductDto> CreateAsync(CreateProductDto createProductDto)
        {
            var convertedEntity = _mapper.Map<Product>(createProductDto);
            var entity = await _productRepository.CreateAsync(convertedEntity);
            return _mapper.Map<CreateProductDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            //var originalEntity = await _productRepository.GetAllAsync();
            var originalEntity = await _productRepository.GetAllProductAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(originalEntity);
        }

        public async Task<IEnumerable<ProductDto>> GetProductByFilterAsync(int? categoryId, int? brandId)
        {
            var filteredEntity = await _productRepository.GetAllProductAsync();

            //Filter
            if(categoryId > 0)
                filteredEntity = filteredEntity.Where(x => x.CategoryId == categoryId);

            if (brandId > 0)
                filteredEntity = filteredEntity.Where(x=>x.BrandId == brandId);

            return _mapper.Map<IEnumerable<ProductDto>>(filteredEntity);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            //var entity = await _productRepository.GetByIdAsync(id);
            var entity = await _productRepository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            var convertedEntity = _mapper.Map<Product>(updateProductDto);
            await _productRepository.UpdateAsync(convertedEntity);
        }
    }
}
