using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partak.Data.Services
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Feilds
        private readonly IApplcationDbContext _context = null;

        private DbSet<TEntity> entities = null;
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (entities == null)
                    entities = _context.Set<TEntity>();

                return entities;
            }
        }
        #endregion
        public EFRepository(IApplcationDbContext context)
        {
            this._context = context;
        }
        public IQueryable<TEntity> Table => Entities;
        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public TEntity GetByIdAsNoTracking(params object[] ids)
        {
            var x = this._context.Set<TEntity>().Find(ids);
            if (x != null)
            {
                this._context.Entry(x).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            return x;
        }
        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this._context.Set<TEntity>().Remove(entity);
            await this._context.SaveChangesAsync();
        }
        public async Task<TEntity> GetByIdAsync(params object[] ids)
        {

            var entity = await this._context.Set<TEntity>().FindAsync(ids);
            return entity;
        }
        public async Task<TEntity> GetByIdAsNoTrackingAsync(params object[] ids)
        {
            var entity = await this._context.Set<TEntity>().FindAsync(ids);
            if (entity != null)
            {
                this._context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            return entity;
        }
        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await this._context.Set<TEntity>().AddAsync(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            this._context.Set<TEntity>().Update(entity);
            await this._context.SaveChangesAsync();
        }
    }
}

