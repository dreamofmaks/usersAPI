using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Users.Data.Interfaces;
using Users.Data.Model;

namespace Users.Data.Infrastructure
{
    public sealed class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly UserContext context;
        private readonly DbSet<TEntity> dbEntities;

        public Repository(UserContext context)
        {
            this.context = context;
            dbEntities = this.context.Set<TEntity>();
        }

        /// <summary>
        /// Adds entity into DbContext
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>added entity</returns>
        public TEntity Add(TEntity entity) => dbEntities.Add(entity).Entity;

        /// <summary>
        /// Add range of entities into DbContext
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(IEnumerable<TEntity> entities) => dbEntities.AddRange(entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true if entity was successfully deleted, and false in other way</returns>
        public bool Delete(TEntity entity) => dbEntities.Remove(entity).Entity != null;

        /// <summary>
        /// Remove range of entities
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteRange(IEnumerable<TEntity> entities) => dbEntities.RemoveRange(entities);

        /// <summary>
        /// Finds and return entity based on PK
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public TEntity GetById(params object[] keys) => dbEntities.Find(keys);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity) => dbEntities.Update(entity).Entity;

        /// <summary>
        /// Get all entity records with included entities
        /// </summary>
        /// <param name="includes"></param>
        /// <returns>IQueryable of all entities with includes entities. if includes is null function is equal to GetAll</returns>
        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = context.Set<TEntity>();
            IQueryable<TEntity> query = dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query ?? dbSet;
        }
    }
}
