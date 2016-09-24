using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Eron.core.DataModel;
using Microsoft.Ajax.Utilities;

namespace Eron.core.DataAccess.Repositories
{
    public class Repository<T,TKey> : IRepository<T,TKey> where T : EntityBase<TKey>
    {
        private ApplicationDbContext _context;
        private Encode.Encode _encode;

        protected Repository(ApplicationDbContext context,Encode.Encode encode)
        {
            this._context = context;
            _encode = encode;
        }

        public virtual List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<List<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual IQueryable<T> GetIQueryable()
        {
            return _context.Set<T>();
        }

        public T Get(TKey id)
        {
            return _context.Set<T>().Find(id);
        }

        public Task<T> GetAsync(TKey id)
        {
            return _context.Set<T>().FindAsync(id);
        }

        public virtual T Get(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }

        public async Task<T> UpdateAsync(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }

        public virtual T Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public async Task<T> InsertAsync(T obj)
        {
            _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public int Remove(TKey id)
        {
            var obj = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(obj);
            return _context.SaveChanges();
        }

        public async Task<int> RemoveAsync(TKey id)
        {
            var obj = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(obj);
            return await _context.SaveChangesAsync();
        }
    }
}
