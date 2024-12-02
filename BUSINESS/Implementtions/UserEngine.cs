using BUSINESS.Contracts;
using COMMON.dtos;
using COMMON.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Implementtions
{
    public class UserEngine : IUserEngine
    {
        private readonly IUnitofWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserEngine(IUnitofWork uow, IHttpContextAccessor httpContextAccessor)
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
        public async Task<bool> UpdateUserSettings(UserSettingsDto userSettings)
        {
            var currentUser = await GetLoggedUser(); 
            currentUser.ProfilePic = userSettings.ProfilePic;
            currentUser.Password = userSettings.Password;
            currentUser.Email = userSettings.Email;
            currentUser.PhoneNumber = userSettings.PhoneNumber;
            currentUser.UserName = userSettings.UserName;


           await _uow.users.UpdateAsync(currentUser.Id.ToString(), currentUser);

            return true;  
        }


    }

}