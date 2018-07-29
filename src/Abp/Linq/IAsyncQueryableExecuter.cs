using SqlSugar;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abp.Linq
{
    /// <summary>
    /// This interface is intended to be used by ABP.
    /// </summary>
    public interface IAsyncQueryableExecuter
    {
        Task<int> CountAsync<T>(ISugarQueryable<T> queryable);

        Task<List<T>> ToListAsync<T>(ISugarQueryable<T> queryable);

        Task<T> FirstOrDefaultAsync<T>(ISugarQueryable<T> queryable);
    }
}