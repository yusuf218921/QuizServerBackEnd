using Core.DataAccess;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    // Question tablosunda db sorguları için arayüz
    public interface IQuestionDal : IEntityRepository<Question>
    {
        List<QuestionDto> GetAllQuestionDto(int quizId);
    }
}
