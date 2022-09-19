using CardProject.Data.Entity.Base;
using CardProject.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Data.Repositories.Implementations
{
    public class ReadOnlyRepository : IReadOnlyRepository
    {
        private readonly DbContext _context;

        public ReadOnlyRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<TEntity>> Get<TEntity>
            (Expression<Func<TEntity, bool>> filter = null, 
            CancellationToken cancellationToken = default) 
            where TEntity : class,IBaseEntity
        {
            var result = await PrepareQueryable(filter)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            //отключаем отслеживание у элементов
            //чтобы не возникало конфликтов при редактировании
            //TODO: решить опциальность этого действия
            if (true)
            {
                DetachedEntities<TEntity>();
            }

            return result;
        }

        public async Task<TEntity> GetFirstOrDefault<TEntity>
            (Expression<Func<TEntity, bool>> filter = null,
            CancellationToken cancellationToken = default)
            where TEntity : class, IBaseEntity
        {
            var items = await PrepareQueryable(filter)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            //отключаем отслеживание у элементов
            //чтобы не возникало конфликтов при редактировании
            //TODO: решить опциальность этого действия
            if (true)
            {
                DetachedEntities<TEntity>();
            }

            return items.FirstOrDefault();
        }

        private IQueryable<TEntity> PrepareQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class,IBaseEntity
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        private void DetachedEntities<TEntity>()
            where TEntity : class, IBaseEntity
        {
            var entries = new List<EntityEntry<TEntity>>(_context.ChangeTracker.Entries<TEntity>());

            foreach(var ent in entries)
            {
                ent.State = EntityState.Detached;
            }
        }

    }
}
