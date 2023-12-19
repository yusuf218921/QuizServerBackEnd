using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concrete.Entityframework.Context;
using Entities.Concretes;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    //EntityFramework kullanılarak Question için db sorgularını implemente eden sınıf,
    //RepositoryBase sınıfını implemente ediyor
    //Generic bir sınıf
    public class EfQuestionDal : EfEntityRepositoryBase<Question, QuizContext>, IQuestionDal
    {
        // Quiz, Question ve Option tablolarının ilişkilerini kullanarak tek bir model oluşturmak için yazılmış metod
        // 3 tablodaki bilgileri id lerine göre eşleyerek QuestionDto sınıfında birleştiriyor
        public List<QuestionDto> GetAllQuestionDto(int quizId)
        {
            using (var context = new QuizContext())
            {
                var result = from quest in context.Questions
                             where quest.QuizID == quizId
                             join option in context.Options on quest.QuestionID equals option.QuestionID into optionGroup
                             select new QuestionDto
                             {
                                 QuestionID = quest.QuestionID,
                                 QuestionText = quest.Text,
                                 Options = optionGroup.Select(o => new OptionDto
                                 {
                                     OptionText = o.OptionText,
                                     IsCorrect = o.IsCorrect
                                 }).ToList(),
                                 Time = quest.Time
                             };

                return result.ToList();
            }
        }
    }
}
