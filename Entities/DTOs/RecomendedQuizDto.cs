using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RecomendedQuizDto
    {
        public int RecomendedQuizID { get; set; }
        public string QuizName { get; set; }
        public string QuizImgUrl { get; set; }
    }
}
