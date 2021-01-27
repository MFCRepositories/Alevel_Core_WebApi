using Business.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Constans;
using Core.Utilities.ResultType;
using Core.Utilities.Security;
using Core.Utilities.Security.Hashing;
using Entities.DTOs;
using System;

namespace Business.Concrete
{
    public class AuthManager
        : IAuthService
    {
        private readonly IUserService userService;
        private readonly ITokenHelper tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            this.userService = userService;
            this.tokenHelper = tokenHelper;
        }
        public EntityResult<AccessToken> CreateAccessToken(User user)
        {
            EntityResult<AccessToken> result = null;
            try
            {
                var accessToken = tokenHelper.CreateToken(user, userService.GetClaims(user).Data);
                if (accessToken != null)
                {
                    return result = new EntityResult<AccessToken>(accessToken);
                }
                else
                {
                    return result = new EntityResult<AccessToken>(null, ResultType.Notfound, Message.AddInfo);
                }
            }
            catch (Exception ex)
            {
                return result = new EntityResult<AccessToken>(null, ResultType.Error, Message.AddError + " " + ex.Message);
            }
        }
        public EntityResult<User> Login(UserForLoginDto userForLoginDto)
        {
            EntityResult<User> result = null;
            try
            {
                User user = userService.GetByEmail(userForLoginDto.Email).Data;
                if (user == null)
                {
                    result = new EntityResult<User>(null, ResultType.Notfound, message: "(Kullanıcı Bulunamadı) " + Message.GetNotFound);
                }
                else
                {
                    if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        result = new EntityResult<User>(null, ResultType.Info, message: "(Kullabıcı Şifre Hatalı) " + Message.GetInfo);
                    }
                    else
                    {
                        result = new EntityResult<User>(user);
                    }
                }
            }
            catch (Exception)
            {
                result = new EntityResult<User>(null, ResultType.Error, message: Message.GetError);
            }
            return result;

        }
        public EntityResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            EntityResult<User> result = null;
            if (UserExists(userForRegisterDto.Email).ResultType == ResultType.Success)
            {
                byte[] passwordHash;
                byte[] passwordSalt;
                HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
                User user = new User()
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = false//TODO : doğrulama mailinden sonra ture olacak

                    //TODO:BaseModel Oluşturulacak
                };
                userService.Add(user);
                //User u =userService.GetByEmail(userForRegisterDto.Email).Data;
                result = new EntityResult<User>(user);
                //TODO : Email Controlu Bu Noktada Yapılcak 
            }
            else
            {
                result = new EntityResult<User>(null,ResultType.Info,"Kullanıcı Mevcut");
            }
            return result;
        }
        public EntityResult UserExists(string email)
        {
            if (userService.GetByEmail(email).Data != null)
            {
                return new EntityResult(ResultType.Info, Message.AddInfo + " Kullanıcı Mevcut");
            }
            return new EntityResult();
        }
    }
}
