using BUSINESS.Contracts;
using COMMON.dtos;
using Microsoft.AspNetCore.Mvc;

namespace Angular_MessagingApp.Server.Controllers
{
  
    public class ChatController : Controller
    {
      
        private readonly IChatEngine _chatEngine;
        public ChatController(IChatEngine chatEngine)
        {
            _chatEngine=chatEngine;
        }

    }
}
