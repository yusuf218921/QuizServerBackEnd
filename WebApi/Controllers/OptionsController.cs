using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : Controller
    {
        IOptionService _optionService;

        public OptionsController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpGet("getquestionoptions")]
        public ActionResult GetOptions(int questionId)
        {
            var result = _optionService.GetQuestionOptions(questionId);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("addoption")]
        public ActionResult AddOption(Option option)
        {
            try
            {
                var result = _optionService.AddOption(option);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deleteoption")]
        public ActionResult DeleteOption(Option option)
        {
            try
            {
                var result = _optionService.DeleteOption(option);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("updateoption")]
        public ActionResult UpdateOption(Option option)
        {
            try
            {
                var result = _optionService.UpdateOption(option);
                if (!result.Success)
                {
                    return BadRequest(result);
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
