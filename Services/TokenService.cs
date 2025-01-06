using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TRIMAPAPI.recordsUser;

namespace TRIMAPAPI.Services
{
    public class TokenService
    {
        public string GerarTokenUsuario(Users usuario)
        {
            // Cria o manipulador de token
            var handler = new JwtSecurityTokenHandler();

            // Define a chave de segurança
            var chave = Encoding.ASCII.GetBytes(SecurityKey.PrivateKey);
            var credenciais = new SigningCredentials(
                new SymmetricSecurityKey(chave),
                SecurityAlgorithms.HmacSha256Signature
            );

            // Define o descritor do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaim(usuario), //assunto vai ser o claim
                SigningCredentials = credenciais,
                Expires = DateTime.UtcNow.AddHours(2),
                // Aqui você pode adicionar mais informações, como claims
            };

            // Cria o token
            var token = handler.CreateToken(tokenDescriptor);

            // Retorna o token como uma string
            return handler.WriteToken(token);
        }

        public static ClaimsIdentity GenerateClaim(Users usuario)
         {

            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, usuario.Email));

            foreach(var role in usuario.Roles)
                ci.AddClaim(new Claim(ClaimTypes.Role, role));

            return ci;
         }

    }
        
}
