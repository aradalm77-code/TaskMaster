using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Domain.Interfaces;

namespace TaskMasterEntity.src.Core.Application.Interfaces
{
    public interface IDb : IDisposable
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;
        IQueryable<TEntity> Set<TEntity>() where TEntity : class, IEntity;
        TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void DeleteByUsername<TEntity>(int id) where TEntity : class, IEntity, new();
        int SaveChanges();
    }
}
