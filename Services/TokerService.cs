using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TRIMAPAPI.recordsUser;

namespace TRIMAPAPI.Services
{
    public class TokerService
    {
        public string GenerateUserToker(Users user)
        {   
            //chama método que gera o Toker
            var handler = new JwtSecurityTokenHandler();

        }
    }
}