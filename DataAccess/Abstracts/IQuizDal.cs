using Core.DataAccess;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IQuizDal : IEntityRepository<Quiz>
    {
        public List<Quiz> GetQuizzesWithPage(int page, int pageSize);
    }
}
