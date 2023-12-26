using Business.Abstracts;
using Core.Utilities.Result;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizScoresController : Controller
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

        [HttpPost("addquizscore")]
        public ActionResult AddQuizScore(QuizScore quizScore)
        {
            var result = _quizScoreService.AddQuizScore(quizScore);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("updatequizscore")]
        public ActionResult UpdateQuizScore(QuizScore quizScore)
        {
            var result = _quizScoreService.UpdateQuizScore(quizScore);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
