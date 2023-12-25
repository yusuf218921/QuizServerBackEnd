using Business.Abstracts;
using Business.BusinessAspects.Autofac;
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
        public QuizManager(IQuizDal quizDal)
        {
            _quizDal = quizDal;
        }
        [SecuredOperation("admin")]
        public IResult AddQuiz(Quiz quiz)
        {
            try
            {
                _quizDal.Add(quiz);
                return new SuccessResult("Quiz Başarıyla eklendi");
            }
            catch(Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            
        }
        [SecuredOperation("admin")]
        public IResult DeleteQuiz(Quiz quiz)
        {
            try
            {
                _quizDal.Delete(quiz);
                return new SuccessResult("Quiz Başarıyla Silindi");
            }
            catch(Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            
        }

        public IDataResult<List<Quiz>> GetAllQuiz()
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetAll().ToList());
        }

        public IDataResult<List<Quiz>> GetAllQuizByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetAll(q => q.CategoryID == categoryId && q.Status == true).ToList());
        }

        public IDataResult<Quiz> getQuizById(int quizId)
        {
            return new SuccessDataResult<Quiz>(_quizDal.Get(q => q.QuizID == quizId));
        }

        public IDataResult<List<Quiz>> GetQuizWithPage(int page, int pageSize)
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetQuizzesWithPage(page,pageSize));
            
        }
        [SecuredOperation("admin")]
        public IResult UpdateQuiz(Quiz quiz)
        {
            _quizDal.Update(quiz);
            return new SuccessResult("Quiz Başarıyla Güncellendi");
        }
    }
}
