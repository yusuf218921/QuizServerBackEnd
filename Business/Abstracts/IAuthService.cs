using Core.Entities.Concretes;
using Core.Utilities.Result;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email, string username);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}