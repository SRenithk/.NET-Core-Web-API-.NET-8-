using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        #region Encapsulation New after Repo
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region Controller New
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            return Ok(await _categoryRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category == null)
            {
                return NotFound($"The data with Id:'{id}' was Not found");
            }
            return Ok(category);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(Category category)
        {
            if(category == null)
            {
                return BadRequest();
            }
            await _categoryRepository.CreateAsync(category);
            return Ok(category);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update(Category category)
        {
            var findcatgory = await _categoryRepository.GetByIdAsync(category.Id);
            if(findcatgory == null)
            {
                return NotFound();
            }
            await _categoryRepository.Update(category);
            return Ok(category);
        }


        [HttpDelete]
        [Route("Delete")]

        public async Task<IActionResult> Delete(int id)
        {
            var findCategory = await _categoryRepository.GetByIdAsync(id);
            if(findCategory == null)
            {
                return NotFound();
            }
            await _categoryRepository.DeleteAsync(findCategory);
            return Ok($"Successfull Deleted with Id '{id}'");
        }
        #endregion
    }
}
