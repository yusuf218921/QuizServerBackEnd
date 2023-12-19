using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concrete.Entityframework.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    //EntityFramework kullanılarak Option için db sorgularını implemente eden sınıf,
    //RepositoryBase sınıfını implemente ediyor
    //Generic bir sınıf
    public class EfOptionDal : EfEntityRepositoryBase<Option, QuizContext>, IOptionDal
    {
    }
}
