using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Jazzy.Component
{
    /// <summary>
    /// 默认仓储接口
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// 获取实体
        /// 对应SELECT
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Queryable<TEntity>() where TEntity : class;

        /// <summary>
        /// 添加实体
        /// 对应INSERT
        /// </summary>
        /// <param name="entity">实体</param>
        void Insert<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// 修改实体
        /// 对应UPDATE
        /// </summary>
        /// <param name="entity">实体</param>
        void Update<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// 修改实体
        /// 对应UPDATE
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="update"></param>
        /// <param name="filter"></param>
        void Update<TEntity>(Expression<Func<TEntity, TEntity>> entity, Expression<Func<TEntity, bool>> filter) where TEntity : class;

        /// <summary>
        /// 删除实体
        /// 对应DELETE
        /// </summary>
        /// <param name="entity">实体</param>
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// 删除实体
        /// 对应DELETE
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        void Delete<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;

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

    /// <summary>
    /// 实体仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Queryable();

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Insert(TEntity entity);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update(TEntity entity);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="update"></param>
        /// <param name="filter"></param>
        void Update(Expression<Func<TEntity, TEntity>> entity, Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Delete(TEntity entity);

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        void Delete(Expression<Func<TEntity, bool>> filter);
    }
}
