using Business.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getallcategories")]
        public ActionResult GetAllCategories()
        {
            var result = _categoryService.GetAllCategory();
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("getcategory")]
        public ActionResult GetCategory(int categoryId)
        {
            var result = _categoryService.GetCategory(categoryId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
    }
}
