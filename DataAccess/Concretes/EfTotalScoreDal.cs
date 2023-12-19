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
    //EntityFramework kullanılarak TotalScore için db sorgularını implemente eden sınıf,
    //RepositoryBase sınıfını implemente ediyor
    //Generic bir sınıf
    public class EfTotalScoreDal : EfEntityRepositoryBase<TotalScore, QuizContext>, ITotalScoreDal
    {
        // İlişkili tablolar için join işlemleri
        public List<TotalScoreDto> GetAllScore()
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
