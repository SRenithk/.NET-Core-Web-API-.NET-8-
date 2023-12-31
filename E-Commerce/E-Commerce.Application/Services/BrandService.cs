using AutoMapper;
using E_Commerce.Application.DTO.Brand;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Services.Interfaces;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<CreateBrandDto> CreateAsync(CreateBrandDto createBrandDto)
        {
            //create instance
            var validator = new CreateBrandDtoValidator();

            // capture Error
            var validationResult = await validator.ValidateAsync(createBrandDto);

            //if any Error occurs
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Brand Input",validationResult); // Custom Exception
            }

            var convertedEntity = _mapper.Map<Brand>(createBrandDto);
            var entity = await _brandRepository.CreateAsync(convertedEntity);
            return _mapper.Map<CreateBrandDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var foundEntity = await _brandRepository.GetByIdAsync(id);
            await _brandRepository.DeleteAsync(foundEntity);
        }

        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var entity = await _brandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandDto>>(entity);  
        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {
            var foundEntity = await _brandRepository.GetByIdAsync(id);
            return _mapper.Map<BrandDto>(foundEntity);
        }

        public async Task UpdateAsync(BrandDto brandDto)
        {
            var convertedEntity = _mapper.Map<Brand>(brandDto);
            await _brandRepository.Update(convertedEntity);
        }
    }
}
