using Abp.Data;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using SqlSugar;

namespace Abp.SqlSugarCore.Repositories
{
    public class SqlSugarCoreRepositoryBase<TEntity> : SqlSugarCoreRepositoryBase<TEntity, int>, IRepository<TEntity>
        where TEntity : class, new()
    {
        private SqlSugarClient _db;

        public SqlSugarCoreRepositoryBase(SqlSugarClient db) : base(db)
        {
            this._db = db;
        }
    }
}
