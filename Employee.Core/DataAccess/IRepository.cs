using System;
using System.Collections.Generic;
using Employee.Data;

namespace Employee.Core.DataAccess
{
    public interface IRepository<T, in TKey> : IDisposable where T : Persistable
    {
        T Delete(T item);
        T Delete(TKey id);
        void Save(T item);
        T FindById(TKey id);
        IEnumerable<T> GetAll();
    }

    public interface IRepository<T> : IRepository<T, int> where T : Persistable { }
}