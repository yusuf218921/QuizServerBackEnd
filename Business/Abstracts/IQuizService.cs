using Business.BusinessAspects.Autofac;
using Core.Utilities.Result;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    // Quiz Servisleri
    public interface IQuizService
    {
        IResult AddQuiz(Quiz quiz);
        IResult DeleteQuiz(Quiz quiz);
        IResult UpdateQuiz(Quiz quiz);
        IDataResult<List<Quiz>> GetAllQuiz();
        IDataResult<List<Quiz>> GetAllQuizByCategoryId(int categoryId);
        IDataResult<Quiz> getQuizById(int quizId);
        IDataResult<List<Quiz>> GetQuizWithPage(int page,int pageSize);
    }
}
