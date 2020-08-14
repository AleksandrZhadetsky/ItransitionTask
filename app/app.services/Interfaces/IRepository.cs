using app.data_access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        Task<TEntity> CreateAsync(TEntity item);
        Task<IEnumerable<TEntity>> GetAllItemsAsync();
        Task<TEntity> GetItemAsync(TKey id);
        Task<TEntity> UpdateAsync(TEntity item);
        Task<TEntity> DeleteAsync(TKey id);
    }
}
