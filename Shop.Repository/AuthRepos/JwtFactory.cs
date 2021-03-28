using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Repository.AuthRepos
{
    public class JwtFactory
    {
        public static string CreateJwt(string Login)
        {
            return JwtToken.CreateToken(Login);
        }
    }
}
