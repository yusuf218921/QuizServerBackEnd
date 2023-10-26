using Business.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecomendedQuizzesController : ControllerBase
    {
        IRecomendedQuizService _recomendedQuizService;

        public RecomendedQuizzesController(IRecomendedQuizService recomendedQuizService)
        {
            _recomendedQuizService = recomendedQuizService;
        }

        [HttpGet("getrecomendedquizzes")]
        public ActionResult GetQuizzes()
        {
            var result = _recomendedQuizService.GetAllQuiz();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("getrecomendedquiz")]
        public ActionResult GetQuiz(int id)
        {
            var result = _recomendedQuizService.GetQuiz(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
    }
}
