using COMMON.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace BUSINESS.Contracts
{
    public interface IMessageEngine
    {
        public Task<List<MessageDto>> GetChatMessages(string chatId);
        public  Task<bool> SendMessage(string chatId, string messageContent, string receiverId);
        public Task AddNewChat(ReceiverDto receiver, string messageContent);
        public  Task<bool> UpdateChatMessages(string chatId, MessageDto message);
    }
}
