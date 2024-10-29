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
    public class MessageRepository : Repository<MessageDto>, IMessageRepository
    {
        private readonly MessagingAppDbContext _context;
        public MessageRepository(MessagingAppDbContext context, string collectionName="Messages") : base(context, collectionName)
        {
            _context = context;
        }
    }
}
