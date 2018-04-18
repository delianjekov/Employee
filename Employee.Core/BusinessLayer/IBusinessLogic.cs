using Employee.Core.DataAccess;
using Employee.Data;

namespace Employee.Core.BusinessLayer
{
    public interface IBusinessLogic<T, in TKey> : IRepository<T, TKey> where T : Persistable { }
}