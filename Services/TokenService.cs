using System;  
using System.Collections.Generic;  
using System.IdentityModel.Tokens.Jwt;  
using System.Linq;  
using System.Security.Claims;  
using System.Text;  
using System.Threading.Tasks;  
using Entities;  
using Microsoft.IdentityModel.Tokens;  

namespace TRIMAPAPI.Services  
{  
    public class TokenService  
    {  
        public static string GenerateToken(Contato contat)  
        {  
            // Chama a chave privada  
            var key = Encoding.ASCII.GetBytes(Key.Secret);  
            var tokenConfig = new SecurityTokenDescriptor  
            {  
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]  
                {  
                    new Claim("id", contat.Id.ToString()),  
                }),  
                Expires = DateTime.UtcNow.AddHours(3),  
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // Fixed the issue here  
            };   

            var tokenHandler = new JwtSecurityTokenHandler();  
            var token = tokenHandler.CreateToken(tokenConfig);  
            return tokenHandler.WriteToken(token);  
        }  
    }  
}