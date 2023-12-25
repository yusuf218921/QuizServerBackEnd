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
    // Quistion Servisleri
    public interface IQuestionService
    {
        IResult AddQuestion(Question question);
        IResult DeleteQuestion(Question question);
        IResult UpdateQuestion(Question question);
        IDataResult<List<Question>> GetQuizQuestions(int quizId);
        IDataResult<List<QuestionDto>> GetQuizQuestionDto(int quizId);
    }
}
