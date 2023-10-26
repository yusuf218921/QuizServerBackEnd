using Business.Abstracts;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizScoresController : ControllerBase
    {
        IQuizScoreService _quizScoreService;

        public QuizScoresController(IQuizScoreService quizScoreService)
        {
            _quizScoreService = quizScoreService;
        }

        [HttpGet("getquizscorebyuserid")]
        public ActionResult GetQuizScoreByUserId(int userId)
        {
            var result = _quizScoreService.GetAllQuizScoreByUserId(userId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("getquizscorebyquizid")]
        public ActionResult GetQuizScoreByQuizId(int quizId)
        {
            var result = _quizScoreService.GetAllQuizScoreByQuizId(quizId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("getquizscore")]
        public ActionResult GetQuizScore(int quizScoreId)
        {
            var result = _quizScoreService.GetQuizScore(quizScoreId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
    }
}
