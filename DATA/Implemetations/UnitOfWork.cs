using COMMON.interfaces;
using DATA.Db;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Implemetations
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly MessagingAppDbContext _context;
  
        public UnitOfWork(MessagingAppDbContext context) 
        {

            _context = context;
            chats = new ChatRepository(_context);
            messages = new MessageRepository(_context);
            users = new UserRepository(_context);

        }

        public IChatRepository chats { get; private set; }

        public IMessageRepository messages { get; private set; }

        public IUserRepository users { get; private set; }

  
    }
}
