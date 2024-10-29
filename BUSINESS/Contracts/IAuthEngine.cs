using COMMON.dtos;
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

        public UserDto Register(UserDto user);
    }
}
