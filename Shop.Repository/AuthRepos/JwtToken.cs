using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.AuthRepos
{
    public class JwtToken
    {
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConfig.KEY));
        }
        public static string CreateToken(string Login)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: JwtConfig.ISSUER,
                    audience: JwtConfig.AUDIENCE,
                    notBefore: now,
                    claims: new List<Claim>{ new Claim(ClaimsIdentity.DefaultNameClaimType, Login) },
                    expires: now.Add(TimeSpan.FromMinutes(JwtConfig.LIFETIME)),
                    signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
