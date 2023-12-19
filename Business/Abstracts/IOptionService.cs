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
        IDataResult<List<Option>> GetQuestionOptions(int questionId);
    }
}
