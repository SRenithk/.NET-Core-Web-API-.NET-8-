using E_Commerce.Web.Data;
using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Encapsulation
        private readonly ApplicationDbContext _dbcontext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        #endregion

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Category>> GetAll()   //or IActionResult Get()
        {
            List<Category> value = [.. _dbcontext.Categories];  // var value = _dbcontext.Categories.ToList();
            return Ok(value);   // or return value;

            //or return _dbcontext.Categories.ToList();
            //or return Ok(_dbcontext.Categories.ToList());   
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]             //removes Undocumented //means we can say : expect these status codes to swagger
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Category> GetById(int id)
        {

            var value = _dbcontext.Categories.FirstOrDefault(x => x.Id == id);

            if (value == null)  return NotFound($"Category not found for id - {id}"); 
            
            return Ok(value);
        }

        [HttpPost]
        [Route("Create")]

        public IActionResult Create([FromBody] Category category) //or public ActionResult<Category> which allows to return category 
        {
            _dbcontext.Categories.Add(category);
            _dbcontext.SaveChanges();
            return Ok(category);
            //or return Ok(category)    - IActionResult
            //or return category        - ActionResult
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Category category)
        {
            //Todo Validation
            _dbcontext.Categories.Update(category);
            _dbcontext.SaveChanges();
            return Ok(category);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteById(int id) {

            var category = _dbcontext.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null) return NotFound();

            _dbcontext.Categories.Remove(category);
            _dbcontext.SaveChanges();
            return Ok($"Successfully Removed of id - {id}");
        }

    }
}
