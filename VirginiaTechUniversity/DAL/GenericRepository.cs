using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace VirginiaTechUniversity.DAL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal SchoolContext context;
        internal DbSet<TEntity> dBSet;


        public GenericRepository(SchoolContext context)
        {
            this.context = context;
            this.dBSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get
        (Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dBSet;

            if (filter != null) query = query.Where(filter);

            foreach (var includeProperty
                in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperties);
            }

            if (orderBy != null)
            { return orderBy(query).ToList(); }
            else
            { return query.ToList(); }
        }

        public virtual TEntity GetById(object Id)
        {
            return dBSet.Find(Id);
        }

        //PURPOSELY LEFT OUT THE VIRTUAL KEYWORD - WHAT WILL HAPPEN?
        public void Insert(TEntity entity)
        {
            dBSet.Add(entity);
        }

           public virtual void Delete(object Id)
        {
            TEntity entityToDelete = dBSet.Find(Id);
            Delete(entityToDelete);
        }

        /*
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dBSet.Attach(entityToDelete);
            }
            dBSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dBSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        */
    }
}