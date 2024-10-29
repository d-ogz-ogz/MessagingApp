using BUSINESS.Contracts;
using COMMON.dtos;
using COMMON.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Implementtions
{
    public class MessageEngine : IMessageEngine
    {

        private readonly IUnitofWork _uow;
        public MessageEngine(IUnitofWork uow)
        {
            _uow = uow;
        }
        public List<MessageDto> GetChatMessages(string chatId)
        {
            List< MessageDto> chatMessages = new List<MessageDto>();
            ChatDto chat = this._uow.chats.GetByIdAsync(chatId).Result;
            var chatmessages = chat.Messages;
            if(chatmessages != null)
            {
                foreach( var message in chatmessages)
                {
                    chatMessages.Add(new MessageDto()
                    {
                        Id = message.Id,
                        Content = message.Content,
                       

                    });
                    chat?.Messages?.Add(message);
                }
                
            }
            return chatMessages;
          

             

        }

        public bool SendMessage(int chatId, bool receiver)
        {
            throw new NotImplementedException();
        }
    }
}
