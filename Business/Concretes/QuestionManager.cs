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
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }
        public IDataResult<List<Question>> GetQuizQuestions(int quizId)
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(q => q.QuizID == quizId).ToList());
        }
    }
}
