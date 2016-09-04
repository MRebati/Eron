using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eron.core.DataModel;

namespace Eron.core.DataAccess.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        List<T> Get();

        Task<List<T>> GetAsync();

        IQueryable<T> GetIQueryable();

        T Get(string id);

        Task<T> GetAsync(string id);

        T Get(Guid id);

        Task<T> GetAsync(Guid id);

        T Update(T obj);

        Task<T> UpdateAsync(T obj);

        T Insert(T obj);

        Task<T> InsertAsync(T obj);

        int Remove(string id);
        Task<int> RemoveAsync(string id);

        int Remove(Guid id);

        Task<int> RemoveAsync(Guid id);
    }
}
