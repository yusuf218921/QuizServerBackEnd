using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Quiz : IEntity
    {
        public int QuizID { get; set; }
        public int CategoryID { get; set; }
        public string QuizName { get; set; }
        public bool Status { get; set; }
    }
}
