﻿using COMMON.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Contracts
{
    public interface IUserEngine
    {
        public Task<bool> UpdateUserSettings(UserSettingsDto userSettings);
       
    }
}
