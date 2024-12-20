﻿using Amazon.Runtime.Internal.Util;
using BUSINESS.Contracts;
using COMMON.dtos;
using COMMON.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Implementtions
{


    public class AuthEngine : IAuthEngine
    {

        private readonly IUnitofWork _uow;
        private readonly IDistributedCache _cache; //veri saklama ve erişim için arayüze ulaşacağız. dağıtılmış bir önbellek sisteminde veri saklamak ve bu verilere erişmek için kullanılan bir yapıdır.
        private readonly IConfiguration _conf;

        public AuthEngine(IUnitofWork uow, IDistributedCache cache,IConfiguration conf)
        {
            _uow = uow;
            _cache = cache;
            _conf = conf;
        }

        private const string SecretKey = "buçokgizlibirşifreanahtarıdırbilginizolsun";
        private const int TokenExpirationMinutes = 30;

        public static string GenerateToken(string tokenModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, tokenModel)
                }),
                Expires = DateTime.UtcNow.AddMinutes(TokenExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }


        public LoginUser Login(LoginDto loggedUser)
        {

            var token = "";
            bool isValidUser = ValidateUser(loggedUser.Password, loggedUser.Id);
            if (!isValidUser)
            {
                throw new UnauthorizedAccessException("Authorization is failed,user is not valid");
            }
            else
            {
                var userData = new UserDto();
                userData = _uow.users.GetByIdAsync(loggedUser.Id).Result;
                if (loggedUser.Email != null)
                {
                    int atIndex = loggedUser.Email.IndexOf("@");
                    if (atIndex > 0)
                    {
                        var tokenModel = loggedUser.Email.Substring(0, atIndex);
                        token = GenerateToken(tokenModel);

                        var cacheOptions = new DistributedCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
                        };

                        ; _cache.SetString(loggedUser.UserName + "token", token, cacheOptions);
                        _cache.SetString(loggedUser.UserName + "_userName", loggedUser.UserName, cacheOptions);


                    }


                }
                return new LoginUser { LoggedUser = userData, Token = "Bearer:"+ token };
            }


        }




        public bool ValidateUser(string password, string id)
        {
            bool res = false;
            try
            {
                var user = _uow.users.GetByIdAsync(id).Result;
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        res = true;

                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }

          public  async Task<UserDto> Register(UserDto user, IFormFile? profilePic =null)
        {
            UserDto registerModel = new UserDto();
            var userData = await _uow.users.GetAllAsync();
            if (user != null)
            {
                foreach (var logModel in userData)
                {
                    if (user.UserName != logModel.UserName && user.Email != logModel.Email && logModel.Password!=null)
                    {
                    
                        if (profilePic != null)
                        {
                            var fileExtension = Path.GetExtension(profilePic.FileName);
                            var fileName = $"{Guid.NewGuid()}{fileExtension}";
                            var filePath = Path.Combine(_conf["FileSettings:UploadPath"], fileName);

                            //resmi kaydet
                            using (var stream= new FileStream(filePath, FileMode.Create))
                            {
                                await profilePic.CopyToAsync(stream);
                            }
                            registerModel.ProfilePic = Path.Combine("uploads", fileName).Replace("\\", "//");
                        }


                        registerModel.UserName = logModel.UserName;
                        registerModel.Email = logModel.Email;
                        registerModel.Name = logModel.Name;
                        registerModel.SurName = logModel.SurName;
                        registerModel.PhoneNumber = logModel.PhoneNumber;
                        var hashedPassword = HashPassword(logModel.Password);
                        registerModel.Password = hashedPassword;
                        registerModel.Consent = logModel.Consent;
                        registerModel.Inform = logModel.Inform;
                        registerModel.isSuccess = true;

                        await _uow.users.CreateAsync(user);
                    }
                    registerModel.isSuccess = false;

                }
            }


            return registerModel;

        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}








////HASHLEME
//Adımlar:
//SHA256 algoritması kullanarak şifreyi hashleyin.
//UTF8 formatında şifreyi byte array'e dönüştürün.
//Hashlenmiş byte dizisini hexadecimal string'e çevirin.



//DOSYA İŞLEMLERİ
//Uzantıyı al
//Benzersiz Dosya Adı Oluştur.
//Dosya yolu oluştur ( wwwroot/uploads altına kaydedilir)
//Dosya Kaydet
//Dosya yolu ekle