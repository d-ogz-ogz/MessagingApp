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
    public class ChatRepository : Repository<ChatDto>, IChatRepository
    {
        private readonly MessagingAppDbContext _context;
        
        public ChatRepository(MessagingAppDbContext context, string collectionName= "Chats") : base(context, collectionName)
        {
            _context = context;
           
        }
    }
}
