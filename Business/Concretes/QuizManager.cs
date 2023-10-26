using Business.Abstracts;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class QuizManager : IQuizService
    {
        IQuizDal _quizDal;
        QuizManager(IQuizDal quizDal)
        {
            _quizDal = quizDal;
        }

        public IDataResult<List<Quiz>> GetAllQuiz()
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetAll().ToList());
        }

        public IDataResult<List<Quiz>> GetAllQuizByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetAll(q => q.CategoryID == categoryId).ToList());
        }

        public IDataResult<Quiz> getQuizById(int quizId)
        {
            return new SuccessDataResult<Quiz>(_quizDal.Get(q => q.QuizID == quizId));
        }
    }
}
