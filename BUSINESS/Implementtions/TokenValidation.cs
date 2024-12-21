using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Implementtions
{
    public class TokenValidation
    {
        private const string SecretKey = "buçokgizlibirşifreanahtarıdırbilginizolsun";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenValidation(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public static ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {

                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "yourIssuer",
                ValidAudience = "yourAudience",
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
            SecurityToken securityToken;
            {
                try
                {
                    var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                    if (securityToken.ValidTo < DateTime.UtcNow)
                    {
                        return null;
                    }
                    return principal;
                }
                catch (SecurityTokenException ex)
                {
                    throw new UnauthorizedAccessException(ex.Message);
                    throw;
                }

            }
        }
        public string GetAccessToken()
        {

            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            var principal = TokenValidation.GetPrincipalFromToken(accessToken);
            if (principal == null)
            {
                throw new UnauthorizedAccessException(nameof(accessToken));

            }
            return accessToken;

        }

    }
}
