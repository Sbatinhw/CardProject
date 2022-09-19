using CardProject.Data.Entity.Base;
using CardProject.Data.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Data.Repositories.Interfaces
{
    public interface IReadOnlyRepository
    {
        Task<ICollection<TEntity>> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            CancellationToken cancellationToken = default)
            where TEntity : class,IBaseEntity;

        Task<TEntity> GetFirstOrDefault<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            CancellationToken cancellationToken = default)
            where TEntity : class, IBaseEntity;
    }
}
