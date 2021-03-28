using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public abstract class User
    {
        //litol comment
        public string ID { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public void ChangeTo(User user)
        {
            this.FristName = user.FristName;
            this.LastName = user.LastName;
        }
    }
}
