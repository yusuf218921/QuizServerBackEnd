using Business.Abstracts;
using Business.BusinessAspects.Autofac;
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
        public OptionManager(IOptionDal optionDal)
        {
            _optionDal = optionDal;
        }
        [SecuredOperation("admin")]
        public IResult AddOption(Option option)
        {
            _optionDal.Add(option);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult DeleteOption(Option option)
        {
            _optionDal.Delete(option);
            return new SuccessResult();
        }

        public IDataResult<List<Option>> GetQuestionOptions(int questionId)
        {
            return new SuccessDataResult<List<Option>>(_optionDal.GetAll(q => q.QuestionID == questionId).ToList());
        }
        [SecuredOperation("admin")]
        public IResult UpdateOption(Option option)
        {
            _optionDal.Update(option);
            return new SuccessResult();
        }
    }
}
