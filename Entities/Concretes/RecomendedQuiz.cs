using DataAccess.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class RecomendedQuiz : IEntity
    {
        public int RecomendedQuizID { get; set; }
        public int QuizID { get; set; }
    }
}
