using Business.Abstracts;
using Core.Utilities.Result;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
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

        [HttpGet("getquestiondtos")]
        public ActionResult GetQuestionDto(int quizId)
        {
            var result = _questionService.GetQuizQuestionDto(quizId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("addquestion")]
        public ActionResult AddQuestion(Question question)
        {
            try
            {
                var result = _questionService.AddQuestion(question);
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

        [HttpPost("deletequestion")]
        public ActionResult DeleteQuestion(Question question)
        {
            try
            {
                var result = _questionService.DeleteQuestion(question);
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

        [HttpPost("updatequestion")]
        public ActionResult UpdateQuestion(Question question)
        {
            try
            {
                var result = _questionService.UpdateQuestion(question);
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
    }
}
