using Business.Abstracts;
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
    public class TotalScoreManager : ITotalScoreService
    {
        ITotalScoreDal _totalScoreDal;

        public TotalScoreManager(ITotalScoreDal totalScoreDal)
        {
            _totalScoreDal = totalScoreDal;
        }

        public IResult AddTotalScore(TotalScore totalScore)
        {
            if(IfUserHaveATotalScore(totalScore.UserID))
            {
                _totalScoreDal.Add(totalScore);
                return new SuccessResult();
            } else
            {
                var temp = _totalScoreDal.Get(t => t.UserID == totalScore.UserID);
                totalScore.Score += temp.Score;
                UpdateTotalScore(totalScore);
                return new SuccessResult();
            }
        }

        public IDataResult<List<TotalScoreDto>> GetAllScore()
        {
            return new SuccessDataResult<List<TotalScoreDto>>(_totalScoreDal.GetAllScore());
        }

        public IDataResult<TotalScore> GetTotalScoreByUserId(int userId)
        {
            return new SuccessDataResult<TotalScore>(_totalScoreDal.Get(t => t.UserID == userId));
        }

        public IResult UpdateTotalScore(TotalScore totalScore)
        {
            _totalScoreDal.Update(totalScore);
            return new SuccessResult();
        }

        private bool IfUserHaveATotalScore (int userId)
        {
            var result = _totalScoreDal.Get(t => t.UserID == userId);
            if(result == null)
            {
                return true;
            }
            return false;
        }
    }
}
