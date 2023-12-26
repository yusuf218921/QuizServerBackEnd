using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Core.Utilities.BusinessRules;
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
            var result = BusinessRules.Run(isOptionFull(option), exactlyOneCorrectAnswer(option), isOptionsHaveCorrectOption(option));

            if (result != null)
                return result;
            _optionDal.Add(option);
            return new SuccessResult("Seçenek Eklendi");
        }
        [SecuredOperation("admin")]
        public IResult DeleteOption(Option option)
        {
            _optionDal.Delete(option);
            return new SuccessResult("Seçenek Silindi");
        }

        public IDataResult<List<Option>> GetQuestionOptions(int questionId)
        {
            return new SuccessDataResult<List<Option>>(_optionDal.GetAll(q => q.QuestionID == questionId).ToList());
        }
        [SecuredOperation("admin")]
        public IResult UpdateOption(Option option)
        {
            _optionDal.Update(option);
            return new SuccessResult("Seçenek Güncellendi");
        }

        private IResult isOptionFull(Option option)
        {
            if(GetQuestionOptions(option.QuestionID).Data.Count == 4)
            {
                return new ErrorResult("option dolu");
            }

            return new SuccessResult();
        }

        private IResult isOptionsHaveCorrectOption(Option option)
        {
            if(GetQuestionOptions(option.QuestionID).Data.Count == 3 && GetQuestionOptions(option.QuestionID).Data.Where(o => o.IsCorrect == false).ToList().Count == 3)
            {
                if(option.IsCorrect)
                {
                    return new SuccessResult();
                } 
                else
                {
                    return new ErrorResult("Bir adet doğru cevap bulunmak zorunda");
                }
            }

            return new SuccessResult();
        }

        private IResult exactlyOneCorrectAnswer(Option option)
        {
            if(GetQuestionOptions(option.QuestionID).Data.Where(o => o.IsCorrect).ToList().Count == 1 && option.IsCorrect == true)
            {
                return new ErrorResult("Hali hazırda bir adet doğru cevap bulunmaktadır.");
            }

            return new SuccessResult();
        }
    }
}
