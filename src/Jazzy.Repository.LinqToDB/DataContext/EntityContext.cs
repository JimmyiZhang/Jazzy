using Jazzy.Component;
using LinqToDB;
using LinqToDB.DataProvider.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Jazzy.Repository.LinqToDB
{
    public class EntityContext : DataContext, IEntityContext
    {
        DataContextTransaction transaction = null;
        private void EnsureTransaction()
        {
            if (transaction == null)
                transaction = this.BeginTransaction(false);
        }

        public EntityContext(string connectionString)
            : base(SQLiteTools.GetDataProvider(), connectionString)
        { }

        public IQueryable<TEntity> Queryable<TEntity>() where TEntity : class
        {
            return this.GetTable<TEntity>().AsQueryable();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            this.EnsureTransaction();
            this.Insert(entity);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            this.EnsureTransaction();
            this.Delete(entity);
        }

        public void Remove<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            this.EnsureTransaction();
            this.GetTable<TEntity>().Where(filter).Delete();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            this.EnsureTransaction();
            this.Update(entity);
        }

        public void Update<TEntity>(Expression<Func<TEntity, TEntity>> setter, Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            this.EnsureTransaction();
            this.GetTable<TEntity>().Where(filter).Update(setter);
        }

        public IEnumerable<TEntity> QuerySql<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void ExecuteSql(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            if (this.transaction != null)
                transaction.CommitTransaction();

            this.transaction = null;
        }

        public void Rollback()
        {
            if (this.transaction != null)
                transaction.RollbackTransaction();
        }
    }
}
