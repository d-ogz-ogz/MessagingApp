using COMMON.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.dtos
{
    public class LoginUser:IEntity
    {
        public string? Id { get; set; }
        public UserDto? LoggedUser { get; set; }
        public string? Token { get; set; }
    }
}
