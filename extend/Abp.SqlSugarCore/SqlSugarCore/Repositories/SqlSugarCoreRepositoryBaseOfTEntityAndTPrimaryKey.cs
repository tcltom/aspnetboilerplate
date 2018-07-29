using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using SqlSugar;

namespace Abp.SqlSugarCore.Repositories
{
    public class SqlSugarCoreRepositoryBase<TEntity, TPrimaryKey> : AbpSqlSugarCoreRepositoryBase<TEntity, TPrimaryKey>, IRepository<TEntity, TPrimaryKey>
        where TEntity : class, new()
    {
        private SqlSugarClient _db;

        public SqlSugarCoreRepositoryBase(SqlSugarClient db) : base(db)
        {
            this._db = db;
        }
    }
}
