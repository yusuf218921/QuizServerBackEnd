using Core.DataAccess;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    // TotalScore tablosunda db sorguları için arayüz
    public interface ITotalScoreDal : IEntityRepository<TotalScore>
    {
        // Total score için model oluşturan metod
        List<TotalScoreDto> GetAllScore();

    }
}
