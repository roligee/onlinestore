using BlastAsia.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain
{
    public interface IRepository<TEntity>
        where TEntity : class
    {

        TEntity Create(TEntity newEntity);

        TEntity Find(object id);

        IEnumerable<TEntity> Find();

        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);

        TEntity Update(TEntity entity);

        void Delete(object id);

    }
}
