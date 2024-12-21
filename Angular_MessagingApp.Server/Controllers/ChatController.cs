using BUSINESS.Contracts;
using COMMON.dtos;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Angular_MessagingApp.Server.Controllers
{
  
    public class ChatController : Controller
    {
      
        private readonly IChatEngine _chatEngine;
        public ChatController(IChatEngine chatEngine)
        {
            _chatEngine=chatEngine;
        }
        [HttpGet("GetUserChats")]
        public async Task<List<ChatDto>> GetUserChats()
        {
            return await _chatEngine.GetUserChats();
        }
        [HttpGet("GetChatById")]
        public async Task<ChatDto> GetChatById(string chatId)
        {
            return await _chatEngine.GetChatById(chatId);
        }

    }
}
