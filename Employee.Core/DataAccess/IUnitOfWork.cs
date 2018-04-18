using System;
using Employee.Data;

namespace Employee.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : Persistable;
    }
}
