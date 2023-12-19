using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    //Toplam skor için model
    public class TotalScoreDto : IDto
    {
        public int TotalScoreID { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
    }
}
