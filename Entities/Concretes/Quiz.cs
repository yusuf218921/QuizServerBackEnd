﻿using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    //Quiz Tablosu
    public class Quiz : IEntity
    {
        public int QuizID { get; set; }
        public int CategoryID { get; set; }
        public string QuizName { get; set; }
        public string QuizImgUrl { get; set; }
        public bool Status { get; set; }
    }
}
