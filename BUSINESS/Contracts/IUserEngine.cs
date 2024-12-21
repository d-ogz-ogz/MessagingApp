using COMMON.dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Contracts
{
    public interface IUserEngine
    {
        public  Task<bool> UpdateUserSettings(UserSettingsDto userSettings, IFormFile profilePic);


    }
}
