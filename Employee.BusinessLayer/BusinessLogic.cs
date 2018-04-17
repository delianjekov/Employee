using Employee.Core.BusinessLayer;
using Employee.Core.DataAccess;

namespace Employee.BusinessLayer
{
    public class BusinessLogic<T, TKey> : IBusinessLogic<T, TKey> where T : class
    {
        private readonly IRepository<T, TKey> _repository;
        public BusinessLogic(IRepository<T, TKey> repository)
        {
            _repository = repository;
        }
        public T FindById(TKey id)
        {
            return _repository.FindById(id);
        }
    }
}
