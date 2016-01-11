using OnlineStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Models;
using BlastAsia.Infra;

namespace OnlineStore.Infra.Persistence
{
    public abstract class RepositoryBase<TEntity> 

        : IRepository<TEntity>
        where TEntity : class
    {
        private IOnlineStoreDbContext context;

        public RepositoryBase(IOnlineStoreDbContext context)
        { 
            this.context = context;
        }

        public TEntity Create(TEntity newEntity)
        {
            context.Set<TEntity>().Add(newEntity);
            context.SaveChanges();

            return newEntity;
        }

        public void Delete(object id)
        {
            var entity = Find(id);
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();

        }

        public IEnumerable<TEntity> Find()
        {
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> spec)
        {
            return context.Set<TEntity>().Where<TEntity>(spec.IsSatisfiedBy).ToList();
        }

        public TEntity Find(object id)
        {
            var entity = context.Set<TEntity>().Find(id);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }
}
