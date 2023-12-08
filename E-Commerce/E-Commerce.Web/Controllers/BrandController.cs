using E_Commerce.Application.DTO.Brand;
using E_Commerce.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController(IBrandService brandService) : ControllerBase //instead of constructor it is another option to encapsulate. It is called Primary constructor
    {
        private readonly IBrandService _brandService = brandService;

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _brandService.GetAllAsync());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _brandService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateAsync(createBrandDto);
            return Ok(createBrandDto);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update(BrandDto brandDto)
        {
            await _brandService.UpdateAsync(brandDto);
            return Ok(brandDto);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task Delete(int id)
        {
           await _brandService.DeleteAsync(id);
        }
    }
}
