using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.UseCases;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace Shop.Repository.AuthRepos
{
    public class Authenticator : IAuthenticator<AuthorizationModel>
    {
        private Context _cont;
        public async Task<bool> LogInAsync(AuthorizationModel model)
        {
            var tempModel = await this._cont.AuthModelsList.Where(obj=>model.Equals(obj)).FirstOrDefaultAsync();
            if(tempModel!=null)
            return true;
            return false;
        }

        public Task LogOutAsync()
        {
            throw new NotImplementedException();
        }
        public Authenticator()
        {
            this._cont = new Context();
        }
    }
}
