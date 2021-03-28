using Shop.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.AuthRepos
{
    public class AuthFactory
    {
        public static IAuthenticator<AuthorizationModel> Create()
        {
            return new Authenticator(); 
        }
    }
}
