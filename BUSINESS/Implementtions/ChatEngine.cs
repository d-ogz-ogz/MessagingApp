using BUSINESS.Contracts;
using COMMON.dtos;
using COMMON.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Implementtions
{
    public class ChatEngine : IChatEngine
    {
        private readonly IUnitofWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatEngine(IUnitofWork uow,IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
           _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<ChatDto>> GetUserChats()
        {
            var user = await MessageEngine.GetLoggedUser(_httpContextAccessor, _uow);

            List<ChatDto> userchats = new List<ChatDto>();
            if (user.Id.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(user));
            }
             var chats = await _uow.chats.GetFilteredAsync(r => r.Id == user.Id);
            if (chats == null || !chats.Any())
            {
                return new List<ChatDto> { new ChatDto() };
            }
          

                foreach (var chat in chats)
                {
                    var lastMessages = await _uow.messages.GetFilteredAsync(r => r.Id == chat.Id);
                    var lastMessageData = lastMessages?.OrderByDescending(r => r.Adding).FirstOrDefault().ToString();
                    userchats.Add(new ChatDto
                    {
                        Id = chat.Id,
                        Receiver = chat.Receiver,
                        Adding = chat.Adding,   
                        LastMessaage = lastMessageData


                    }) ;              
            }
               
            
            return userchats;
        }

        public async Task<ChatDto> GetChatById(string chatId)
        {
            var selectedChat = await _uow.chats.GetByIdAsync(chatId);
            if (selectedChat == null)
                return new ChatDto();

            var receiver = await _uow.receivers.GetByIdAsync(selectedChat?.Receiver.Id);
            var messages = await _uow.messages.GetFilteredAsync(res => res.Id == chatId);

            return new ChatDto
            {
                Id = selectedChat.Id,
                Receiver = receiver,
                Messages = messages
            };
        }




    }
}

