using Business.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalScoresController : ControllerBase
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

        [HttpGet("getalltotalscores")]
        public ActionResult GetTotalScoreByUserId(int userId)
        {
            var result = _totalScoreService.GetTotalScoreByUserId(userId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

    }
}
