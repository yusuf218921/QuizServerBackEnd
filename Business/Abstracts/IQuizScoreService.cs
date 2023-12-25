using Core.Utilities.Result;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    // QuizScore Servisleri
    public interface IQuizScoreService
    {
        IResult AddQuizScore(QuizScore quizScore);
        IResult UpdateQuizScore( QuizScore quizScore);
        IDataResult<List<QuizScore>> GetAllQuizScoreByQuizId(int quizId);
        IDataResult<QuizScore> GetQuizScore(int quizScoreId);
        IDataResult<List<QuizScore>> GetAllQuizScoreByUserId(int userId);
    }
}
