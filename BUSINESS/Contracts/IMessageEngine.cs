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
        public List<MessageDto> GetChatMessages(string chatId);
        public bool SendMessage(int chatId, bool receiver);
    }
}
