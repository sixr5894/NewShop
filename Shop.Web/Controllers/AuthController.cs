using Microsoft.AspNetCore.Mvc;
using Shop.Repository;
using Shop.Repository.AuthRepos;
using Shop.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private IAuthenticator<AuthorizationModel> _authenticator;
        [HttpGet]        
        public IActionResult Index()
        {
            var temp = new AuthorizationModel() { Login = "user", Password = "user" };
            return Json(temp);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AuthorizationModel model)
        {
            var answer = await this._authenticator.LogInAsync(model);
            if (!answer)
            {
                return BadRequest(new { errorText = "Invalid username or password.", status = false });
            }
            var anString = JwtFactory.CreateJwt(model.Login);
            return Json(new {token = anString, login = model.Login, status = true});
        }
        public AuthController()
        {
            this._authenticator = AuthFactory.Create();
        }
    }
}
