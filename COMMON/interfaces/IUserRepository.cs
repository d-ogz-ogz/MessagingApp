using COMMON.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.interfaces
{
    public interface IUserRepository:IRepository<UserDto>
    {
    }
}
