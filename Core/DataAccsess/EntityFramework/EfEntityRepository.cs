using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccsess.EntityFramework
{
    /// <summary>
    /// Entity Framework altyaısı için oluşturulmuş temel CURD işlemleri için BaseRepo sınıfı
    /// </summary>
    /// <typeparam name="TEntity">Database Tabolosu</typeparam>
    /// <typeparam name="TContext">Entity Framework Dbcontext yapısı</typeparam>
    public class EfEntityRepository<TEntity, TContext>
        : IEntityRepository<TEntity>
        where TEntity :class,IEntity
        where TContext :DbContext

    {
        protected readonly TContext Context;
        public EfEntityRepository(TContext context)
        {
            Context = context;
        }
        public int Add(TEntity entity)
        {
            Context.Add(entity);
            return Context.SaveChanges();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return await Context.Set<TEntity>().ToListAsync();
            else
                return await Context.Set<TEntity>().Where(filter).ToListAsync();
        }
        public int Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return Context.SaveChanges();
        }
        public int Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();
        }
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                //Unmanaged resource    
                Disposed = true;
            }
        }
        private bool Disposed { get; set; }
    }
}
