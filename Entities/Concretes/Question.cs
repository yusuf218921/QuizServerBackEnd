using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Question : IEntity
    {
        public int QuestionID { get; set; }
        public int QuizID { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public int Time { get; set; }
        public byte Status { get; set; }
    }
}
