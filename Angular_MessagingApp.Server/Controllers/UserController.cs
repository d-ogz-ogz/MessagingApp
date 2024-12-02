using BUSINESS.Contracts;
using BUSINESS.Implementtions;
using COMMON.dtos;
using Microsoft.AspNetCore.Mvc;

namespace Angular_MessagingApp.Server.Controllers
{

    public class UserController : Controller
     
    {
        private readonly IUserEngine _userEngine;

        public UserController(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

       public Task<bool> UpdateUserSettings(UserSettingsDto userSettings)
        {
           return this._userEngine.UpdateUserSettings(userSettings);
        }
    }
}
