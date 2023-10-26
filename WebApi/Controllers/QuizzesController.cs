using Business.Abstracts;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        IQuizService _quizService;

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        [HttpGet("getallquiz")]
        public ActionResult GetAllQuiz()
        {
            var result = _quizService.GetAllQuiz();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("getallquizbycategoryid")]
        public ActionResult GetAllQuizByCategoryId(int categoryId)
        {
            var result = _quizService.GetAllQuizByCategoryId(categoryId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("getquiz")]
        public ActionResult GetQuiz(int quizId)
        {
            var result = _quizService.getQuizById(quizId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
    }
}
