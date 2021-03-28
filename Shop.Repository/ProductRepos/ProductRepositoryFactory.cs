using Shop.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.ProductRepos
{
    public class ProductRepositoryFactory
    {
        public static IRepository<ProductModel> CreateProductRepository()
        {
            var temp = (IRepository<ProductModel>)new ProductRepository();
            return temp;
        }
    }
}
