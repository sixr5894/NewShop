using Microsoft.EntityFrameworkCore;
using Shop.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.ProductRepos
{
    public class ProductRepository : IRepository<ProductModel>
    {
        private Context _cont;

        public async Task AddModelAsync(ProductModel temp)
        {
            try
            {
                await this._cont.ProductModelsList.AddAsync(temp);
                await this._cont.SaveChangesAsync();
            }
            catch { }

        }

        public async Task<List<ProductModel>> AllModelsAsync()
        {
            return await this._cont.ProductModelsList.AsNoTracking().ToListAsync() ;
        }

        public async Task DeleteAsync(ProductModel temp)
        {
            try
            {
                this._cont.ProductModelsList.Remove(temp);
                await this._cont.SaveChangesAsync();
            }
            catch{ }
        }

        public async Task EditModelAsync(ProductModel temp)
        {
            var product = await this._cont.ProductModelsList.Where(obj=>obj.ID==temp.ID).FirstOrDefaultAsync();
            if (product != null)
            {
                product.ChangeTo(temp);
                await _cont.SaveChangesAsync();
            }
        }
        public ProductRepository()
        {
            _cont = new Context();
        }

    }
}
