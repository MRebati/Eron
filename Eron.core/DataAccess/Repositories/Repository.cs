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
    public class Repository<T> : IRepository<T> where T : EntityBase
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

        public virtual T Get(string id)
        {
            var code = _encode.GetGuid(id);
            return _context.Set<T>().Find(code);
        }

        public async Task<T> GetAsync(string id)
        {
            var code = _encode.GetGuid(id);
            return await _context.Set<T>().FindAsync(code);
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

        public virtual int Remove(string id)
        {
            var code = _encode.GetGuid(id);
            var obj = _context.Set<T>().Find(code);
            _context.Set<T>().Remove(obj);
            return _context.SaveChanges();

        }

        public async Task<int> RemoveAsync(string id)
        {
            var obj = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(obj);
            return await _context.SaveChangesAsync();
        }

        public int Remove(Guid id)
        {
            var obj = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(obj);
            return _context.SaveChanges();
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var obj = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(obj);
            return await _context.SaveChangesAsync();
        }
    }
}
