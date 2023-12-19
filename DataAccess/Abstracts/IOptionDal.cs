using Core.DataAccess;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    // Option tablosunda db sorguları için arayüz
    public interface IOptionDal : IEntityRepository<Option>
    {
    }
}
