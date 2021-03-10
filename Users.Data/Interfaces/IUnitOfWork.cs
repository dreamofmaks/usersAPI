using System;
using Microsoft.EntityFrameworkCore;
using Users.Data.Model;

namespace Users.Data.Interfaces
{
    public interface IUnitOfWork<TEntity> : IDisposable
        where TEntity : class, IEntity
    {
        DbContext db { get; }

        IRepository<TEntity> GetRepository();

        void SaveChanges();
    }
}
