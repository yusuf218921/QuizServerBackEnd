﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    //Seçenekler için model
    public class OptionDto
    {
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
