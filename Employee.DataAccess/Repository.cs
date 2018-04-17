using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Employee.Core.DataAccess;

namespace Employee.DataAccess
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly DbContext _context;
        public Repository(EmployeeModelContainer context)
        {
            _context = context;
        }

        public T Delete(T item)
        {
            return _context.Set<T>().Remove(item);
        }

        public T FindById(TKey id)
        {
            var result = _context.Set<T>().Find(id);
            if (result == null)
                throw new KeyNotFoundException($"Object of type {typeof(T)} with ID: {id} cannot be found.");
            return result;
        }

        public void Save(T item)
        {
            _context.Set<T>().AddOrUpdate(item);
        }
    }
}