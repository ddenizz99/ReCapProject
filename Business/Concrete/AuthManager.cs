using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Mail;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
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
        IMailService _mailService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMailService mailService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mailService = mailService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new SuccessDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);

            var mailMessage = new EmailMessage()
            {
                ToAddresses = new List<EmailAddress> 
                { 
                    new EmailAddress() { Name = user.FirstName + " " + user.LastName, Address = user.Email }, 
                    new EmailAddress() { Name = "Info", Address = "info@rentacar.com" } 
                },
                FromAddresses = new List<EmailAddress> 
                { 
                    new EmailAddress() { Name = "Rent A Car", Address = "mail@rentacar.com" } 
                },
                Subject = "Yeni Kayıt",
                Content = "<h1>{0}</h1><br><p>" + user.FirstName + " " + user.LastName + " adlı kullanıcı sisteme kayıt oldu.</p>"
            };

            _mailService.Send(mailMessage);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
