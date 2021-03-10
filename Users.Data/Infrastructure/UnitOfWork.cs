using System;
using Microsoft.EntityFrameworkCore;
using Users.Data.Interfaces;
using Users.Data.Model;

namespace Users.Data.Infrastructure
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>
        where TEntity : class, IEntity
    {
        private readonly UserContext context;

        public UnitOfWork(UserContext context)
        {
            this.context = context;
        }

        public DbContext db => context;

        public IRepository<TEntity> GetRepository() => new Repository<TEntity>(context);

        public void SaveChanges() => context.SaveChanges();

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                db.Dispose();
            }

            disposed = true;
        }
    }
}
