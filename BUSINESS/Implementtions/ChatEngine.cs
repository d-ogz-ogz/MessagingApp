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
    public class ChatEngine : IChatEngine
    {
        private readonly IUnitofWork _uow;
        public ChatEngine(IUnitofWork uow)
        {
            _uow = uow;
        }
        public async Task<List<ChatDto>> GetChats(string userId)
        {
            List<ChatDto> userchats = new List<ChatDto>();
            ; var chats = await _uow.chats.GetFilteredAsync(r => r.Id == userId);
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
                return null;

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

