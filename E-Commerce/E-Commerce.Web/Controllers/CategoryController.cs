using E_Commerce.Application.ApplicationConstants;
using E_Commerce.Application.Common.API_Response;
using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.Services;
using E_Commerce.Application.Services.Interfaces;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Encapsulation old
        //private readonly ApplicationDbContext _dbcontext;

        //public CategoryController(ApplicationDbContext dbContext)
        //{
        //    _dbcontext = dbContext;
        //}
        #endregion

        #region Controller Old
        //[HttpGet]
        //[Route("GetAll")]
        //public ActionResult<List<Category>> GetAll()   //or IActionResult Get()
        //{
        //    List<Category> value = [.. _dbcontext.Categories];  // var value = _dbcontext.Categories.ToList();
        //    return Ok(value);   // or return value;

        //    //or return _dbcontext.Categories.ToList();
        //    //or return Ok(_dbcontext.Categories.ToList());   
        //}

        //[HttpGet]
        //[Route("GetById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]             //removes Undocumented //means we can say : expect these status codes to swagger
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<Category> GetById(int id)
        //{

        //    var value = _dbcontext.Categories.FirstOrDefault(x => x.Id == id);

        //    if (value == null) return NotFound($"Category not found for id - {id}");

        //    return Ok(value);
        //}

        //[HttpPost]
        //[Route("Create")]

        //public IActionResult Create([FromBody] Category category) //or public ActionResult<Category> which allows to return category 
        //{
        //    _dbcontext.Categories.Add(category);
        //    _dbcontext.SaveChanges();
        //    return Ok(category);
        //    //or return Ok(category)    - IActionResult
        //    //or return category        - ActionResult
        //}

        //[HttpPut]
        //[Route("Update")]
        //public IActionResult Update([FromBody] Category category)
        //{
        //    //Todo Validation
        //    _dbcontext.Categories.Update(category);
        //    _dbcontext.SaveChanges();
        //    return Ok(category);
        //}

        //[HttpDelete]
        //[Route("Delete")]
        //public IActionResult DeleteById(int id)
        //{

        //    var category = _dbcontext.Categories.FirstOrDefault(x => x.Id == id);

        //    if (category == null) return NotFound();

        //    _dbcontext.Categories.Remove(category);
        //    _dbcontext.SaveChanges();
        //    return Ok($"Successfully Removed of id - {id}");
        //}
        #endregion

        #region Encapsulation New after Services

        private readonly ICategoryService _categoryService;
        protected APIResponse _response;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _response = new APIResponse();
        }
        #endregion

        #region Controller New
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                    return _response;
                }
                var category = await _categoryService.GetAllAsync();

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = category;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
            
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<APIResponse>> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    //return NotFound($"The data with Id:'{id}' was Not found");
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                }
                _response.StatusCode=HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = category;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<APIResponse>> Create(CreateCategoryDto categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.AddError(ModelState.ToString());
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                    return _response;
                }
                var entity = await _categoryService.CreateAsync(categoryDto);

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.CreateOperationSuccess;
                _response.Result = entity;

                //return Ok(categoryDto);
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<APIResponse>> Update(CategoryDto categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.AddError(ModelState.ToString());
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                    return _response;
                }

                var findcatgory = await _categoryService.GetByIdAsync(categoryDto.Id);
                if (findcatgory == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.AddError(CommonMessage.RecordNotFound);
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                    return _response;
                }
                await _categoryService.UpdateAsync(categoryDto);
                
                _response.StatusCode=HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.UpdateOperationSuccess; 
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }


        [HttpDelete]
        [Route("Delete")]

        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            try
            {
                var findCategory = await _categoryService.GetByIdAsync(id);
                if (findCategory == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    return _response;
                }
                await _categoryService.DeleteAsync(id);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.DeleteOperationSuccess;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                _response.AddError(CommonMessage.SystemError);
            }  
            return _response;

            //return Ok($"Successfull Deleted with Id '{id}'");
        }
        #endregion
    }
}
