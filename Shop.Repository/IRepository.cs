using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> AllModelsAsync();
        Task AddModelAsync(T temp);
        Task DeleteAsync(T temp);
        Task EditModelAsync(T temp);
    }
}
