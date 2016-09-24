using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eron.core.DataModel;

namespace Eron.core.DataAccess.Repositories
{
    public interface IRepository<T,TKey> where T : EntityBase<TKey>
    {
        List<T> Get();

        Task<List<T>> GetAsync();

        IQueryable<T> GetIQueryable();

        T Get(TKey id);

        Task<T> GetAsync(TKey id);

        T Update(T obj);

        Task<T> UpdateAsync(T obj);

        T Insert(T obj);

        Task<T> InsertAsync(T obj);

        int Remove(TKey id);
        Task<int> RemoveAsync(TKey id);
    }
}
