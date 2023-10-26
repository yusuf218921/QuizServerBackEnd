using Core.DataAccess.EntityFramework;
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
    public class EfTotalScoreDal : EfEntityRepositoryBase<TotalScore, QuizContext>, ITotalScoreDal
    {
        public List<TotalScoreDto> getAllScore()
        {
            using (var context = new QuizContext())
            {
                var result = from t in context.TotalScores
                             join u in context.Users
                             on t.UserID equals u.UserID
                             select new TotalScoreDto
                             {
                                 TotalScoreID = t.TotalScoreID,
                                 Username = u.Username,
                                 Score = t.Score
                             };
                return result.ToList();
            }
        }
    }
}
