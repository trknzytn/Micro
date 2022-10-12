using Micro.Dal.Abstracts.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Dal.Concrates.Repo
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        DbContext Context;
        public EntityRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Add(entity);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> GetById()
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        public void Update(TEntity entitiy, int id)
        {
            try
            {
                TEntity val = Context.Set<TEntity>().Find(id);
                val = entitiy;
                Context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
    }
}
