using Jazzy.Component;
using LinqToDB;
using System;
using System.Linq.Expressions;

namespace Jazzy.Repository.LinqToDB
{
    public class UnitOfWork : IUnitOfWork, IUnitOfTrack
    {
        private EntityContext dbContext;
        public UnitOfWork(IEntityContext context)
        {
            this.dbContext = context as EntityContext;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            this.dbContext.Add(entity);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            this.dbContext.Remove(entity);
        }

        public void Remove<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            this.dbContext.Remove(filter);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            this.dbContext.Update(entity);
        }

        public void Update<TEntity>(Expression<Func<TEntity, TEntity>> setter, Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            this.dbContext.Update(setter, filter);
        }

        public void Commit()
        {
            dbContext.Commit();
        }

        public void Rollback()
        {
            dbContext.Rollback();
        }

        public IUnitOfTrack GetTrack()
        {
            return this;
        }
    }
}
