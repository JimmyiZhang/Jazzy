using System;
using System.Linq.Expressions;

namespace Jazzy.Component
{
    /// <summary>
    ///  数据单元跟踪接口
    /// </summary>
    public interface IUnitOfTrack
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(Expression<Func<TEntity, TEntity>> setter, Expression<Func<TEntity, bool>> filter) where TEntity : class;

        void Remove<TEntity>(TEntity entity) where TEntity : class;

        void Remove<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;
    }
}
