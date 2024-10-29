using COMMON.dtos;
using COMMON.interfaces;
using DATA.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Implemetations
{
    public class UserRepository : Repository<UserDto>, IUserRepository
    {
        private readonly MessagingAppDbContext _context;
        public UserRepository(MessagingAppDbContext context, string collectionName="Users") : base(context, collectionName)
        {
            _context = context;
        }
    }
}
