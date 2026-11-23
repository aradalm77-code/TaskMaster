using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;
using TaskMaster.Persistence.MapEntity;

namespace TaskMaster.Persistence.DataBaseContext
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry(entity).State = EntityState.Modified;
        }
    }
}