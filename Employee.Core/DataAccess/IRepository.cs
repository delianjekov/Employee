namespace Employee.Core.DataAccess
{
    public interface IRepository<T, in TKey> where T : class
    {
        T Delete(T item);
        void Save(T item);
        T FindById(TKey id);
    }
}
