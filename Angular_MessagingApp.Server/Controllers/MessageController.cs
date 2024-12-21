using Azure.Messaging;
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
        [HttpGet("SendMessage")]
        public async Task<bool> SendMessage(string chatId, string messageContent, string receiverId)
        {
            return await _messageEngine.SendMessage(chatId, messageContent,receiverId);
        }
        [HttpPost("AddNewChat")]
        public async Task AddNewChat(ReceiverDto receiver, string messageContent)
        {
             await _messageEngine.AddNewChat(receiver, messageContent);
        }
        [HttpGet("GetChatMessages")]
        public async Task<List<MessageDto>> GetChatMessages(string chatId)
        {
            var res = await _messageEngine.GetChatMessages(chatId);
            return res;
        }
        public async Task<bool> UpdateChatMessages(string chatId, MessageDto message)
        {
            var res= await this._messageEngine.UpdateChatMessages(chatId, message);
            return res;
        }
    }
}

