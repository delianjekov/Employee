using System.Collections.Generic;
using Employee.Core.BusinessLayer;
using Employee.Core.DataAccess;
using Employee.Data;

namespace Employee.BusinessLayer
{
    public class BusinessLogic<T, TKey> : IBusinessLogic<T, TKey> where T : Persistable
    {
        private readonly IRepository<T, TKey> _repository;
        public BusinessLogic(IRepository<T, TKey> repository)
        {
            _repository = repository;
        }

        public T Delete(T item)
        {
            return _repository.Delete(item);
        }

        public T Delete(TKey id)
        {
            return _repository.Delete(id);
        }

        public void Save(T item)
        {
            _repository.Save(item);
        }

        public T FindById(TKey id)
        {
            return _repository.FindById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
