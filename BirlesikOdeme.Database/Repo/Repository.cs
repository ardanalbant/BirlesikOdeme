using BirlesikOdeme.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Database.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DatabaseModelEntities context;
        private DbSet<T> dbSet;
        public Repository(DatabaseModelEntities Context)
        {
            context = Context;
            context.Configuration.LazyLoadingEnabled = false;
            dbSet = context.Set<T>();
        }

        public virtual T FindById(object EntityId, List<string> includes = null)
        {
            if (includes != null)
                foreach (var include in includes)
                    dbSet.Include(include);
            return dbSet.Find(EntityId);
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null, List<string> includes = null)
        {
            if (Filter != null)
            {
                IQueryable<T> query = context.Set<T>();
                if (includes != null)
                    foreach (var include in includes)
                        query = query.Include(include);
                return query.Where(Filter);
            }

            return dbSet;
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void InsertList(List<T> entity)
        {
            entity.ForEach(p => dbSet.Add(p));
        }

        public virtual void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object EntityId)
        {
            T entityToDelete = dbSet.Find(EntityId);
            Delete(entityToDelete);
        }

        public virtual void Delete(T Entity)
        {
            if (context.Entry(Entity).State == EntityState.Detached) //Concurrency için 
            {
                dbSet.Attach(Entity);
            }

            dbSet.Remove(Entity);
        }
    }
}