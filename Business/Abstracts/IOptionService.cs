using Core.Utilities.Result;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    // Option Servisleri
    public interface IOptionService
    {
        IResult AddOption(Option option);
        IResult DeleteOption(Option option);
        IResult UpdateOption(Option option);

        IDataResult<List<Option>> GetQuestionOptions(int questionId);
    }
}
