using CardProject.Data.Entity.Base;
using CardProject.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Data.Repositories.Implementations
{
    public class Repository: IRepository
    {
        //TODO: массив с добавленными но не сохраненными в бд элементами
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class,IBaseEntity
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
