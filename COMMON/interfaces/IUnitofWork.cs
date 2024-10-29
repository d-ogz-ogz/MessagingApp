using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.interfaces
{
    public interface IUnitofWork
    {
        IChatRepository chats { get; }
        IMessageRepository messages { get; }
        IUserRepository users { get; }

    
    }
}
