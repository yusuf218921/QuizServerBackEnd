using Core.DataAccess;
using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    //User Tablosunda db sorguları için arayüz
    public interface IUserDal : IEntityRepository<User>
    {
        //User rollerini çekmek için
        List<OperationClaim> GetClaims(User user);
    }
}