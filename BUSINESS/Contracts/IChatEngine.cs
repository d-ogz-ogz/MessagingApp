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
        public  Task<List<ChatDto>> GetChats(string userId);
        public  Task<ChatDto> GetChatById(string chatId);


    }
}
