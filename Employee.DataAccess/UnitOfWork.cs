using System;
using System.Data.Entity;
using Employee.Core.DataAccess;
using Employee.Data;

namespace Employee.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly bool _readOnly;
        private bool _disposed;

        public UnitOfWork(DbContext context, bool readOnly)
        {
            _context = context;
            _readOnly = readOnly;
        }

        public IRepository<T> GetRepository<T>() where T : Persistable
        {
            return new Repository<T>(_context);
        }

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
            if (!_readOnly)
                _context.SaveChanges();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}