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
        #region Encapsulated
        private readonly ApplicationDbContext _dbcontext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        #endregion

        [HttpPost]
        public IActionResult Create([FromBody] Category category )
        {
            _dbcontext.Categories.Add(category);
            _dbcontext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            List<Category> value = [.. _dbcontext.Categories];
            return value;
        }
    }
}
