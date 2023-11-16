using Core.Entities.Concretes;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByMailOrUserName(string email,string username);
        IDataResult<User> GetByMail(string email);
    }
}