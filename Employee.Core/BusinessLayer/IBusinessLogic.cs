namespace Employee.Core.BusinessLayer
{
    public interface IBusinessLogic<out T, in TKey> where T : class
    {
        T FindById(TKey id);
    }
}