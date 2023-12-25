using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalScoresController : Controller
    {
        ITotalScoreService _totalScoreService;
        public TotalScoresController(ITotalScoreService totalScoreService)
        {
            _totalScoreService = totalScoreService;
        }

        [HttpGet("getalltotalscores")]
        public ActionResult GetAllTotalScores()
        {
            var result = _totalScoreService.GetAllScore();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("gettotalscoresbyid")]
        public ActionResult GetTotalScoreByUserId(int userId)
        {
            var result = _totalScoreService.GetTotalScoreByUserId(userId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("addtotalscore")]
        public ActionResult AddTotalScore(TotalScore totalScore)
        {
            var result = _totalScoreService.AddTotalScore(totalScore);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

    }
}
