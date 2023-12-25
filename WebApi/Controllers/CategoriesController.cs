using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
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

        [HttpPost("addcategory")]
        public ActionResult AddCategory(Category category)
        {
            try
            {
                var result = _categoryService.AddCategory(category);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("updatecategory")]
        public ActionResult UpdateCategory(Category category)
        {
            try
            {
                var result = _categoryService.UpdateCategory(category);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deletecategory")]
        public ActionResult DeleteCategory(Category category)
        {
            try
            {
                var result = _categoryService.DeleteCategory(category);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
