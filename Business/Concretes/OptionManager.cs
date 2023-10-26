using Business.Abstracts;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class OptionManager : IOptionService
    {
        IOptionDal _optionDal;
        OptionManager(IOptionDal optionDal)
        {
            _optionDal = optionDal;
        }
        public IDataResult<List<Option>> GetQuestionOptions(int questionId)
        {
            return new SuccessDataResult<List<Option>>(_optionDal.GetAll(q => q.QuestionID == questionId).ToList());
        }
    }
}
