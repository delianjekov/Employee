using Employee.Core.DataAccess;
using Employee.Data;

namespace Employee.Core.BusinessLayer
{
    public interface IBusinessLogicFactory
    {
        IBusinessLogic<T, int> Create<T>(IUnitOfWork uow) where T : Persistable;

        TBusinessLayer CreateSpecific<TEntity, TBusinessLayer>(IUnitOfWork uow)
            where TEntity : Persistable
            where TBusinessLayer : IBusinessLogic<TEntity, int>;
    }
}