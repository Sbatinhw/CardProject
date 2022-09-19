using CardProject.Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Data.Repositories.Interfaces
{
    public interface IRepository
    {
        void Create<TEntity>(TEntity entity)
            where TEntity: class, IBaseEntity;

        void Update<TEntity>(TEntity entity) 
            where TEntity: class, IBaseEntity;

        void Delete<TEntity>(TEntity entity)
            where TEntity: class, IBaseEntity;

        Task Save(CancellationToken cancellationToken = default);
    }
}
