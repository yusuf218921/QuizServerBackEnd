using Core.DataAccess;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    // QuizScore tablosunda db sorguları için arayüz
    public interface IQuizScoreDal : IEntityRepository<QuizScore>
    {
    }
}
