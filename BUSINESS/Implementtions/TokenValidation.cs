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
    }
}
