using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlastAsia.Infra
{
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
        ISpecification<TEntity> And(ISpecification<TEntity> specification);
        ISpecification<TEntity> Or(ISpecification<TEntity> specification);
        ISpecification<TEntity> Not(ISpecification<TEntity> specification);

    }
}
