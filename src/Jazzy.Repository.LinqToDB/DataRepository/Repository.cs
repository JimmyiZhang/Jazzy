using Jazzy.Component;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Jazzy.Repository.LinqToDB
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private EntityContext context;
        private UnitOfWork unit;
        private IUnitOfTrack track;

        public Repository(IEntityContext context, IUnitOfWork unit)
        {
            this.context = context as EntityContext;
            this.unit = unit as UnitOfWork;
            this.track = unit.GetTrack();
        }

        public IQueryable<TEntity> Queryable()
        {
            return this.context.Queryable<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            this.track.Add<TEntity>(entity);
        }

        public void Update(TEntity entity)
        {
            this.track.Update<TEntity>(entity);
        }

        public void Update(Expression<Func<TEntity, TEntity>> setter, Expression<Func<TEntity, bool>> filter)
        {
            this.track.Update<TEntity>(setter, filter);
        }

        public void Delete(TEntity entity)
        {
            this.track.Remove<TEntity>(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            this.track.Remove<TEntity>(filter);
        }
    }
}
