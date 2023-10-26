using Business.Abstracts;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class RecomendedQuizManager : IRecomendedQuizService
    {
        IRecomendedQuizDal _recomendedQuizDal;

        public RecomendedQuizManager(IRecomendedQuizDal recomendedQuizDal)
        {
            _recomendedQuizDal = recomendedQuizDal;
        }

        public IDataResult<List<RecomendedQuizDto>> GetAllQuiz()
        {
            return new SuccessDataResult<List<RecomendedQuizDto>>(_recomendedQuizDal.GetAllQuiz().ToList());
        }

        public IDataResult<RecomendedQuiz> GetQuiz(int id)
        {
            return new SuccessDataResult<RecomendedQuiz>(_recomendedQuizDal.Get(q => q.RecomendedQuizID == id));
        }
    }
}
