using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace Abp.SqlSugarCore.Repositories
{
    public interface ISqlSugarCoreRepository<TEntity> : IRepository<TEntity, int> where TEntity : class
    {
    }
}
