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
    public class EfQuizDal : EfEntityRepositoryBase<Quiz, QuizContext>, IQuizDal
    {
        public List<Quiz> GetQuizzesWithPage(int page, int pageSize)
        {
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
