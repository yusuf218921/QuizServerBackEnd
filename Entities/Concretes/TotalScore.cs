using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    //Total Score Tablosu
    public class TotalScore : IEntity
    {
        public int TotalScoreID { get; set; }
        public int UserID { get; set; }
        public int Score { get; set; }
    }
}
