using Shop.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UseCases
{
    public class AuthorizationModel
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Equals(AuthorizationModel auth)
        {
            return this.Login == auth.Login && this.Password == auth.Password;
        }
    }
}
