using System;
using System.Linq;
using Employee.Core.BusinessLayer;
using Employee.Core.DataAccess;
using Employee.Data;

namespace Employee.BusinessLayer
{
    public class BusinessLogicFactory : IBusinessLogicFactory
    {
        public TBusinessLayer CreateSpecific<TEntity, TBusinessLayer>(IUnitOfWork uow)
            where TEntity : Persistable
            where TBusinessLayer : IBusinessLogic<TEntity, int>
        {
            var repository = uow.GetRepository<TEntity>();
            var spacializedBusinessLayerType = GetType().Assembly.GetTypes().SingleOrDefault(t => t.Name == $"{typeof(TEntity).Name}BusinessLogic");
            if (spacializedBusinessLayerType != null)
                return (TBusinessLayer)Activator.CreateInstance(spacializedBusinessLayerType, repository);
            return (TBusinessLayer)Create<TEntity>(uow);
        }

        public IBusinessLogic<T, int> Create<T>(IUnitOfWork uow) where T : Persistable
        {
            var repository = uow.GetRepository<T>();
            return new BusinessLogic<T, int>(repository);
        }
    }
}