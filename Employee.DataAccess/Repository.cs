using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Employee.Core.DataAccess;
using Employee.Data;

namespace Employee.DataAccess
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : Persistable
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        public T Delete(T item)
        {
            if (_context.Entry(item).State == EntityState.Detached)
                _context.Set<T>().Attach(item);
            return _context.Set<T>().Remove(item);
        }

        public T Delete(TKey id)
        {
            return _context.Set<T>().Remove(FindById(id));
        }

        public T FindById(TKey id)
        {
            var result = _context.Set<T>().Find(id);
            if (result == null)
                throw new KeyNotFoundException($"Object of type {typeof(T)} with ID: {id} cannot be found.");
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Save(T item)
        {
            _context.Set<T>().AddOrUpdate(item);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class Repository<T> : Repository<T, int>, IRepository<T> where T : Persistable
    {
        public Repository(DbContext context) : base(context) { }
    }
}