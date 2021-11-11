using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Data.Services
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task DeleteAsync(TEntity entity);
        TEntity GetByIdAsNoTracking(params object[] ids);
        Task UpdateAsync(TEntity entity);
        Task InsertAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(params object[] ids);
        Task<TEntity> GetByIdAsNoTrackingAsync(params object[] ids);
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
    }
}
