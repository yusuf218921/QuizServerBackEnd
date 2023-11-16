using Core.DataAccess.EntityFramework;
using Core.Entities.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concrete.Entityframework.Context;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfRecomendedQuizDal : EfEntityRepositoryBase<RecomendedQuiz, QuizContext>, IRecomendedQuizDal
    {
        public List<RecomendedQuizDto> GetAllQuiz()
        {
            using (var context = new QuizContext())
            {
                var result = from r in context.RecomendedQuizzes
                             join q in context.Quizzes
                             on r.QuizID equals q.QuizID
                             select new RecomendedQuizDto
                             {
                                 RecomendedQuizID = r.RecomendedQuizID,
                                 QuizName = q.QuizName,
                                 QuizImgUrl = q.QuizImgUrl
                             };
                return result.ToList();
            }
        }
    }
}
