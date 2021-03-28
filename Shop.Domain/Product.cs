using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public abstract class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public void ChangeTo(Product prod)
        {
            this.Name = prod.Name;
            this.Price = prod.Price;
        }
    }
}
