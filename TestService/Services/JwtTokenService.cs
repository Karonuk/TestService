using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestService.DataBase;
using TestService.DataBase.Entites;

namespace TestService.Services
{
    public interface IJwtTokenService
    {
        string CreateToken(User user);
    }
    public class JwtTokenService : IJwtTokenService
    {
        public string CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>()
            {
                new Claim("id",user.Id.ToString()),
                new Claim("name",user.Email),
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Test Task Service"));
            var signinCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
               signingCredentials: signinCredentials,
               expires: DateTime.Now.AddDays(1),
               claims: claims
               );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
