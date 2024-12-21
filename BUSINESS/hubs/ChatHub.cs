using BUSINESS.Implementtions;
using COMMON.dtos;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.hubs
{
    public class ChatHub:Hub
    {
        private static readonly Dictionary<string,string> UserConnections= new Dictionary<string,string>();
        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var accessToken = httpContext.Request.Query["access_token"];
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new UnauthorizedAccessException("Token can not be empty");
            }

            var principal= TokenValidation.GetPrincipalFromToken(accessToken);
            if (principal == null) {
                throw new UnauthorizedAccessException("Token is not valid");
            }

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(!string.IsNullOrEmpty(userId)) {
                Context.Items["UserId"] = userId;
            }

            return base.OnConnectedAsync();
        }


        public async Task SendMessageClient(int chatId,MessageDto message,string notification,string receiverId)
        {
            await Clients.User(receiverId).SendAsync("ReceiveMessage",chatId,message, notification);
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userId= Context.Items["UserId"]?.ToString();
            if (string.IsNullOrEmpty(userId)) {
                UserConnections.Remove(userId);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
