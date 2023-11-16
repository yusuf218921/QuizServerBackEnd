using Business.Abstracts;
using Business.Constants;
using Core.Entities.Concretes;
using Core.Utilities.Result;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                Username = userForRegisterDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new Core.Utilities.Results.SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.LoginError);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.LoginError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email,string username)
        {
            if (_userService.GetByMailOrUserName(email,username).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new Core.Utilities.Results.SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}