using Core.DataAccess;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    // Quiz tablosunda db sorguları için arayüz
    public interface IQuizDal : IEntityRepository<Quiz>
    {
        // Quizleri Sayfa sayfa getirmek için yazılmış metod implemente eden sınıfta override ediliyor.
        public List<Quiz> GetQuizzesWithPage(int page, int pageSize);
    }
}
