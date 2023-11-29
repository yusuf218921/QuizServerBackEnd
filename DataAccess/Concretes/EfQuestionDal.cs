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
    public class EfQuestionDal : EfEntityRepositoryBase<Question, QuizContext>, IQuestionDal
    {
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
