using BUSINESS.Contracts;
using COMMON.dtos;
using Microsoft.AspNetCore.Mvc;

namespace Angular_MessagingApp.Server.Controllers
{
  
    public class MessageController : Controller
    {
      
        private readonly IMessageEngine _messageEngine;
        public MessageController(IMessageEngine messageEngine)
        {
            _messageEngine = messageEngine;
        }
        [HttpGet("GetChatMessages")]
        public MessageDto GetChatMessages(int chatId){
            return new MessageDto { };
        }

        
        [HttpGet("SendMessage")]
        public bool SendMessage(int chatId,bool receiver)
        {
            return true;
        }
    }
}
