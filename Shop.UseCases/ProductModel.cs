using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UseCases
{
    public class ProductModel:Product
    {
        //small com
        public string ImagePath { get; set; }
        public void ChangeTo(ProductModel prod)
        {
            this.Name = prod.Name;
            this.Price = prod.Price;
            this.ImagePath = prod.ImagePath;
        }
    }
}
