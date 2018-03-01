using System;
using System.Linq;
using System.Linq.Expressions;

namespace Jazzy.Component
{
    /// <summary>
    /// 仓储接口基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepositoryBase<TEntity> : IRepository
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
