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
    public class QuizScoreManager : IQuizScoreService
    {
        IQuizScoreDal _quizScoreDal;
        public QuizScoreManager(IQuizScoreDal quizScoreDal)
        {
            _quizScoreDal = quizScoreDal;
        }

        public IResult AddQuizScore(QuizScore quizScore)
        {
            if(IfTheQuizHasBeenSoldBefore(quizScore))
            {
                _quizScoreDal.Add(quizScore);
                return new SuccessResult();
            } else
            {
                UpdateQuizScore(quizScore);
                return new SuccessResult();
            }
            
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

        public IResult UpdateQuizScore(QuizScore quizScore)
        {
            _quizScoreDal.Update(quizScore);
            return new SuccessResult();
        }

        private bool IfTheQuizHasBeenSoldBefore(QuizScore quizScore)
        {
            var _quizScore = _quizScoreDal.Get(q => q.QuizID == quizScore.QuizID);
            if (_quizScore != null)
            {
                return false;
            }

            return true;
        }
    }
}
