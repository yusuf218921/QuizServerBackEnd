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
    //EntityFramework kullanılarak RecomendedQuiz için db sorgularını implemente eden sınıf,
    //RepositoryBase sınıfını implemente ediyor
    //Generic bir sınıf
    public class EfRecomendedQuizDal : EfEntityRepositoryBase<RecomendedQuiz, QuizContext>, IRecomendedQuizDal
    {
        // RecomendedQuiz için Quizle olan id ilişkisi sayesinde RecomendedQuizDto sınıfında
        // birleştirerek yeni bir model oluşturan metod
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
