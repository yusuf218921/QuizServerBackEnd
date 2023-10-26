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
    public class QuizScoreManager : IQuizScoreService
    {
        IQuizScoreDal _quizScoreDal;
        QuizScoreManager(IQuizScoreDal quizScoreDal)
        {
            _quizScoreDal = quizScoreDal;
        }

        public IDataResult<List<QuizScore>> GetAllQuizScoreByQuizId(int quizId)
        {
            return new SuccessDataResult<List<QuizScore>>(_quizScoreDal.GetAll(q => q.QuizID == quizId).ToList());
        }

        public IDataResult<List<QuizScore>> GetAllQuizScoreByUserId(int userId)
        {
            return new SuccessDataResult<List<QuizScore>>(_quizScoreDal.GetAll(q => q.UserID == userId).ToList());
        }

        public IDataResult<QuizScore> GetQuizScore(int quizScoreId)
        {
            return new SuccessDataResult<QuizScore>(_quizScoreDal.Get(q => q.QuizScoreID == quizScoreId));
        }
    }
}
