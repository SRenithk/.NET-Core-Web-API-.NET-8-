using E_Commerce.Application.DTO.Product;
using E_Commerce.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase  //primary constructor
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }

        [HttpGet]
        [Route("Filter")]
        public async Task<ActionResult> GetFilteredProducts(int? categoryId, int brandId)
        {
            return Ok(await _productService.GetProductByFilterAsync(categoryId, brandId));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(CreateProductDto createProductDto)
        {
            return Ok(await _productService.CreateAsync(createProductDto));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateAsync(updateProductDto);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task Delete(int id)
        {
            await _productService.DeleteAsync(id);
        }
    }
}
