namespace Employee.Core.DataAccess
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork ReadWrite { get; }
        IUnitOfWork ReadOnly { get; }
    }
}