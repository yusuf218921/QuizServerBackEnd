﻿using Business.Abstracts;
using Core.Entities.Concretes;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMailOrUserName(string email, string username)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email || u.Username== username));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=> u.Email== email));
        }
    }
}