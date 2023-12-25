using Core.Utilities.Result;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    // TotalScore Servisleri
    public interface ITotalScoreService
    {
        IResult AddTotalScore(TotalScore totalScore);
        IResult UpdateTotalScore(TotalScore totalScore);
        IDataResult<List<TotalScoreDto>> GetAllScore();
        IDataResult<TotalScore> GetTotalScoreByUserId(int userId);
    }
}
