using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }
        [SecuredOperation("admin")]
        public IResult AddQuestion(Question question)
        {
            _questionDal.Add(question);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult DeleteQuestion(Question question)
        {
            _questionDal.Delete(question);
            return new SuccessResult();
        }

        public IDataResult<List<QuestionDto>> GetQuizQuestionDto(int quizId)
        {
            return new SuccessDataResult<List<QuestionDto>>(_questionDal.GetAllQuestionDto(quizId));
        }

        public IDataResult<List<Question>> GetQuizQuestions(int quizId)
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(q => q.QuizID == quizId).ToList());
        }
        [SecuredOperation("admin")]
        public IResult UpdateQuestion(Question question)
        {
            _questionDal.Update(question);
            return new SuccessResult();
        }
    }
}
