using Business.Abstracts;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("getquestions")]
        public ActionResult GetQuestions(int quizId) 
        {
            var result = _questionService.GetQuizQuestions(quizId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
    }
}
