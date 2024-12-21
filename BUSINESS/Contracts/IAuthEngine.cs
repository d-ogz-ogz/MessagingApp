using COMMON.dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Contracts
{
    public interface IAuthEngine
    {
        public LoginUser Login(LoginDto loggedUser);

        public  Task<UserDto> Register(UserDto user, IFormFile? profilePic = null);
    }
}
