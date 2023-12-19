using Core.DataAccess.EntityFramework;
using Core.Entities.Abstracts;
using DataAccess.Abstracts;
using DataAccess.Concrete.Entityframework.Context;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    //EntityFramework kullanılarak Quiz için db sorgularını implemente eden sınıf,
    //RepositoryBase sınıfını implemente ediyor
    //Generic bir sınıf
    public class EfQuizDal : EfEntityRepositoryBase<Quiz, QuizContext>, IQuizDal
    {
        public List<Quiz> GetQuizzesWithPage(int page, int pageSize)
        {
            //Tek seferde bütün quizleri getirmek yerine sayfa sayfa getirmesini sağlamak için yazılmış metod
            using (var context = new QuizContext())
            {
                var quizzes = context.Quizzes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

                return quizzes;
            }
        }
    }
}
