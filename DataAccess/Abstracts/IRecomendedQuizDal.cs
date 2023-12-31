﻿using Core.DataAccess;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    // RecomendedQuiz tablosunda db sorguları için arayüz
    public interface IRecomendedQuizDal : IEntityRepository<RecomendedQuiz>
    {
        // RecomendedQuiz için Model oluşturan metod
        List<RecomendedQuizDto> GetAllQuiz();
    }
}
