using COMMON.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Contracts
{
    public interface IChatEngine
    {
        public  Task<List<ChatDto>> GetUserChats();
        public  Task<ChatDto> GetChatById(string chatId);


    }
}
