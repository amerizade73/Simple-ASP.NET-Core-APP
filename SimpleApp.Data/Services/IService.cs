using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Data
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(params object[] ids);
        Task<TEntity> GetByIdAsNoTrackingAsync(params object[] ids);
        Task DeleteAsync(params object[] ids);
        Task UpdateAsync(TEntity entity);
        Task InsertAsync(TEntity entity);
        Task<List<TEntity>> SearchAsync();
    }
}
