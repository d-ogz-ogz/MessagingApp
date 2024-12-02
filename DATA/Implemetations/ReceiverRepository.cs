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
    public class ReceiverRepository : Repository<ReceiverDto>, IReceiverRepository
    {
        private readonly MessagingAppDbContext _context;
        
        public ReceiverRepository(MessagingAppDbContext context, string collectionName= "Receivers") : base(context, collectionName)
        {
            _context = context;
           
        }
    }
}
