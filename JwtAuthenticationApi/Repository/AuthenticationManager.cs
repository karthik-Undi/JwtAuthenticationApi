using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtAuthenticationApi.Model;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthenticationApi.Repository
{
    public class AuthenticationManager : IAuthenticationManager
    {
        JwtAuthenticationContext _context = new JwtAuthenticationContext();
        private readonly string tokenKey;
        public AuthenticationManager(string Tokenkey)
        {
            this.tokenKey = Tokenkey;
        }


        public  string Authenticate(string Username,string password)
        {
            if(!_context.LoginDetails.Any(u=>u.Username==Username && u.Password == password))
            {
                return null;

            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
