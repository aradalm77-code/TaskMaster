using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Domain.Interfaces;

namespace TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance
{
    public class DataBaseContext : DbContext, IDb
    {
        public DataBaseContext() : base("name=DefaultConnection")
        {
        }
        public DbSet<User> Users { get; set; }


        TEntity IDb.Add<TEntity>(TEntity entity)
        {
            return base.Set<TEntity>().Add(entity);
        }

        void IDb.DeleteById<TEntity>(int id)
        {
            var entity = new TEntity { Id = id };
            base.Set<TEntity>().Attach(entity);
            base.Set<TEntity>().Remove(entity);
        }

        IQueryable<TEntity> IDb.Query<TEntity>()
        {
            return base.Set<TEntity>().AsNoTracking();
        }

        void IDb.Remove<TEntity>(TEntity entity)
        {
            if (Entry(entity).State == EntityState.Detached)
            {
                base.Set<TEntity>().Attach(entity);
            }
            base.Set<TEntity>().Remove(entity);
        }

        IQueryable<TEntity> IDb.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                HasRequired(u => u.Person)
                    .WithMany()
                    .HasForeignKey(u => u.PersonId);
                HasIndex(i => i.Username).IsUnique();
            }
        }
    }
}