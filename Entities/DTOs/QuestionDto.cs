using Core.Entities.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class QuestionDto : IDto
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public List<OptionDto> Options { get; set; }
        public int Time { get; set; }
    }
}
