using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Jazzy.Component
{
    /// <summary>
    /// 数据操作接口
    /// 完整的数据操作接口
    /// </summary>
    public interface IEntityContext
    {
        IQueryable<TEntity> Queryable<TEntity>() where TEntity : class;

        void Add<TEntity>(TEntity entity) where TEntity : class;

        void Remove<TEntity>(TEntity entity) where TEntity : class;

        void Remove<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(Expression<Func<TEntity, TEntity>> setter, Expression<Func<TEntity, bool>> filter) where TEntity : class;

        void Commit();

        void Rollback();
        
        /// <summary>
        /// 通过sql语句查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TEntity> QuerySql<TEntity>(string sql, params object[] parameters) where TEntity : class;

        /// <summary>
        /// 通过sql语句执行
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        void ExecuteSql(string sql, params object[] parameters);
    }
}


