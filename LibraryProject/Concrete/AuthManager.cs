using Business.Abstract;
using Business.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;

            return new SuccessDataResult<AccessToken>(_tokenHelper.CreateToken(user, claims), Message.TokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userCheck = _userService.GetUserByEmail(userForLoginDto.Email);
            if (userCheck == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userCheck.Data.PasswordHash, userCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Message.PasswordError);
            }

            return new SuccessDataResult<User>(userCheck.Data);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
           
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(user, Message.RegisteredMessage);
        }

        public IResult UserExists(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user.Data != null)
            {
                return new ErrorResult(Message.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
