using BUSINESS.Contracts;
using COMMON.dtos;
using COMMON.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Implementtions
{
    public class MessageEngine : IMessageEngine
    {

        private readonly IUnitofWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MessageEngine(IUnitofWork uow, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDto> GetLoggedUser()
        {
            UserDto res = new UserDto();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!userId.IsNullOrEmpty())
            {
                var user = await _uow.users.GetByIdAsync(userId);

            }
            else
            {
                throw new ArgumentNullException("User ID can not be null");

            }

            return res ?? new UserDto();
        }

        public async Task<List<MessageDto>> GetChatMessages(string chatId)
        {
            if (chatId.IsNullOrEmpty())
            {
                throw new ArgumentNullException("Chat Id is required");
            }


            var chat = await _uow.chats.GetByIdAsync(chatId);

            if (chat == null || chat.Messages == null)
            {
                return new List<MessageDto>();
            }


            return chat.Messages.Select(mes => new MessageDto
            {

                Id = mes.Id,
                ChatId = mes.ChatId,
                Content = mes.Content,
                Adding = mes.Adding
            }).ToList();




        }

        public async Task<bool> SendMessage(string chatId, string messageContent, string receiverId)
        {
            Boolean res = false;


            if (messageContent.IsNullOrEmpty() || chatId.IsNullOrEmpty() || receiverId.IsNullOrEmpty())
            {
                throw new ArgumentNullException("Parameters can not be null");
            }
            MessageDto newMessage = new MessageDto();

            newMessage.Content = messageContent;
            newMessage.Adding = DateTime.UtcNow;
            newMessage.ChatId = chatId;

            var currentChat = await _uow.chats.GetByIdAsync(chatId);
            if (currentChat != null)
            {
                await _uow.messages.CreateAsync(newMessage);
                currentChat?.Messages?.Add(newMessage);
                await _uow.chats.UpdateAsync(chatId, currentChat);



                res = true;
            }
            else
            {
                var receiver = await _uow.receivers.GetByIdAsync(receiverId);

                await AddNewChat(receiver, messageContent);

                res = true;
            }





            return res;
        }

        public async Task AddNewChat(ReceiverDto receiver, string messageContent)
        {
            //oturum bilgisinden userId
            var user = await GetLoggedUser();
            if (user == null)
            {
                throw new InvalidOperationException("error!");

            }
            try
            {
                var userTask = await _uow.users.GetByIdAsync(user.Id);
                var receiverTask = await _uow.receivers.GetByIdAsync(receiver.Id);

                if (userTask != null && receiverTask != null)
                {
                    var chatNModel = new ChatDto
                    {
                        Receiver = receiverTask,
                        UserId = user.Id,
                        Adding = DateTime.UtcNow, 
                        Messages=new List<MessageDto>
                        {
                            new MessageDto
                            {
                                Content= messageContent,
                                Adding= DateTime.UtcNow
                            }
                        }
                    };


                }
                else
                {
                    throw new ArgumentException("User or Receiver data can not be null");
                }
            }


            catch (Exception e)
            {


                throw new Exception("Something went wrong by adding new chat" + e.Message);
            }
        }


    }

}
