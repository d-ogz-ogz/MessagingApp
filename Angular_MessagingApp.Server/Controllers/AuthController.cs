using BUSINESS.Contracts;
using COMMON.dtos;
using Microsoft.AspNetCore.Mvc;

namespace Angular_MessagingApp.Server.Controllers
{

    public class AuthController : Controller

    {

       
        private readonly IAuthEngine _authEngine;
        public AuthController(IAuthEngine authEngine)
        {
            _authEngine = authEngine;
        }
        public LoginUser Login(LoginDto loggedUser)
        {
           return this._authEngine.Login(loggedUser);

        }
        public  async Task<UserDto> Register([FromForm] UserDto user, IFormFile? profilePic =null)
        {
            return await this._authEngine.Register(user,profilePic);
        }
    }
}
