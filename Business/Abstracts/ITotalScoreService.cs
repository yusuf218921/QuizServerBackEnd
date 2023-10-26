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
    public interface ITotalScoreService
    {
        IDataResult<List<TotalScoreDto>> getAllScore();
        IDataResult<TotalScore> getTotalScoreByUserId(int userId);
    }
}
