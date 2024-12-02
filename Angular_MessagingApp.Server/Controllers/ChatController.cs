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
        public async Task<List<ChatDto>> GetChats(string userId)
        {
            return await _chatEngine.GetChats(userId);
        }
        public async Task<ChatDto> GetChatById(string chatId)
        {
            return await _chatEngine.GetChatById(chatId);
        }

    }
}
