using Core.Entity.Concrete;
using Core.Utilities.ResultType;
using Core.Utilities.Security;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        EntityResult<User> Register(UserForRegisterDto userForRegisterDto);
        EntityResult<User> Login(UserForLoginDto userForLoginDto);
        EntityResult UserExists(string email);
        EntityResult<AccessToken> CreateAccessToken(User user);
    }
}
