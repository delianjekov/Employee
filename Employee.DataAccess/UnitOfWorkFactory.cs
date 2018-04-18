using Employee.Core.DataAccess;

namespace Employee.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private IUnitOfWork Create(bool readOnly)
        {
            return new UnitOfWork(new EmployeeModelContainer(), readOnly);
        }

        IUnitOfWork IUnitOfWorkFactory.ReadWrite => Create(false);

        IUnitOfWork IUnitOfWorkFactory.ReadOnly => Create(true);
    }
}