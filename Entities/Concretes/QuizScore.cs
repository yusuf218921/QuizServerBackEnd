using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    //Quiz Score Tablosu
    public class QuizScore : IEntity
    {
        public int QuizScoreID { get; set; }
        public int QuizID { get; set; }
        public int UserID { get; set; }
        public int Score { get; set; }
    }
}
