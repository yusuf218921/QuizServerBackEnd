using Business.Abstracts;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : Controller
    {
        IQuizService _quizService;

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("getallquizzeswithpage")]
        public ActionResult GetAllQuizWithPage(int page,int pageSize)
        {
            var result = _quizService.GetQuizWithPage(page, pageSize);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
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

        [HttpGet("getquizwithpagebycategoryid")]
        public ActionResult GetQuizByCategoryWithPage(int categoryId, int page = 1, int pageSize = 5)
        {
            var result = _quizService.GetAllQuizByCategoryId(categoryId);
            if (!result.Success)
                return BadRequest(result.Message);

            var totalCount = result.Data.Count;
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var quizzesPerPage = result
                .Data.Skip((page - 1) * pageSize)
                .Take(pageSize);

            return Ok(quizzesPerPage);
        }
    }
}
