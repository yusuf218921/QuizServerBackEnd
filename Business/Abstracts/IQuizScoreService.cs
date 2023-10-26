using Core.Utilities.Result;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IQuizScoreService
    {
        IDataResult<List<QuizScore>> getAllQuizScoreByQuizId(int quizId);
        IDataResult<QuizScore> getQuizScore(int quizScoreId);
        IDataResult<List<QuizScore>> getAllQuizScoreByUserId(int userId);
    }
}
