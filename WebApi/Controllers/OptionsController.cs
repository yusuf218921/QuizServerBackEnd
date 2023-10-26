using Business.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
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
    }
}
