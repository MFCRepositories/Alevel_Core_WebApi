using Business.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.ResultType;
using Core.Utilities.Security;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            EntityResult<AccessToken> accessToken = null;
            var userResult = authService.Login(userForLoginDto);
            switch (userResult.ResultType)
            {
                case ResultType.Success:
                    accessToken = authService.CreateAccessToken(userResult.Data);
                    switch (accessToken.ResultType)
                    {
                        case ResultType.Success:
                            return Ok(accessToken.Data);
                        case ResultType.Info:
                            break;
                        case ResultType.Error:
                            break;
                        case ResultType.Notfound:
                            break;
                        case ResultType.Warning:
                            break;
                        default:
                            break;
                    }
                    break;
                case ResultType.Info:
                    break;
                case ResultType.Error:
                    break;
                case ResultType.Notfound:
                    break;
                case ResultType.Warning:
                    break;
                default:
                    break;
            }
            return BadRequest();
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            EntityResult<User> result = authService.Register(userForRegisterDto);
            switch (result.ResultType)
            {
                case ResultType.Success:
                   var d= authService.CreateAccessToken(result.Data).Data;
                    return Ok(d);
                case ResultType.Info:
                    return BadRequest(result.Message);
                case ResultType.Error:
                    return BadRequest(result.Message);
                case ResultType.Notfound:
                    break;
                case ResultType.Warning:
                    break;
                default:
                    break;
            }
            return BadRequest();
        }
    }
}