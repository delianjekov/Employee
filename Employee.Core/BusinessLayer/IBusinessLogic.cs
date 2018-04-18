using Employee.Data;

namespace Employee.Core.BusinessLayer
{
    public interface IBusinessLogic<out T, in TKey> where T : Persistable
    {
        T FindById(TKey id);
    }
}