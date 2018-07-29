using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using SqlSugar;

namespace Abp.SqlSugarCore.Repositories
{
    /// <summary>
    ///     Base class to implement <see cref="ISqlSugarCoreRepository{TEntity,TPrimaryKey}" />.
    ///     It implements some methods in most simple way.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TPrimaryKey">The type of the primary key.</typeparam>
    /// <seealso cref="ISqlSugarCoreRepository{TEntity,TPrimaryKey}" />
    public abstract class AbpSqlSugarCoreRepositoryBase<TEntity, TPrimaryKey> : AbpRepositoryBase<TEntity, TPrimaryKey> where TEntity : class, new()
    {
        private SqlSugarClient _db;

        public AbpSqlSugarCoreRepositoryBase(SqlSugarClient db)
        {
            this._db = db;
            this._db.Aop.OnLogExecuted = (sql, pars) => //SQL执行完事件
            {
#if DEBUG
                Console.WriteLine($"#############sql执行时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}#################");
                Console.WriteLine($"执行sql:{sql}。");
                if (pars != null && pars.Length > 0)
                {
                    var arrpar = pars.Select(p => p.ParameterName + ":" + p.Value).ToList();
                    Console.WriteLine($"执行参数:{string.Join(",", arrpar)}。");
                }
                else
                {
                    Console.WriteLine($"执行参数:无。");
                }

                Console.WriteLine($"##########################################################################################");
#endif
            };
        }

        #region 从abp默认接口IRepository<TEntity, TPrimaryKey>中拷贝过来
        public override int Count()
        {
            return this._db.Queryable<TEntity>().Count();
        }

        public override Task<int> CountAsync()
        {
            return this._db.Queryable<TEntity>().CountAsync();
        }

        public override void Delete(TPrimaryKey id)
        {
            this._db.Deleteable<TEntity>().In(id).ExecuteCommand();
        }

        public override Task DeleteAsync(TPrimaryKey id)
        {
            return this._db.Deleteable<TEntity>().In(id).ExecuteCommandAsync();
        }

        public override void Delete(TEntity entity)
        {
            this._db.Deleteable<TEntity>().Where(entity).ExecuteCommand();
        }

        public override Task DeleteAsync(TEntity entity)
        {
            return this._db.Deleteable<TEntity>().Where(entity).ExecuteCommandAsync();
        }

        public override TEntity FirstOrDefault(TPrimaryKey id)
        {
            return this._db.Queryable<TEntity>().In(id).First();
        }

        public override Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return this._db.Queryable<TEntity>().In(id).FirstAsync();
        }

        public override TEntity Get(TPrimaryKey id)
        {
            ////没有数据时返回空,不会抛异常
            return this._db.Queryable<TEntity>().In(id).First();//.InSingle(id); 
        }

        public override Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return this._db.Queryable<TEntity>().In(id).FirstAsync();
        }

        public override List<TEntity> GetAllList()
        {
            return this._db.Queryable<TEntity>().ToList();
        }

        public override Task<List<TEntity>> GetAllListAsync()
        {
            return this._db.Queryable<TEntity>().ToListAsync();
        }


        public override TEntity Insert(TEntity entity)
        {
            return this._db.Insertable<TEntity>(entity).ExecuteReturnEntity();
        }

        public override Task<TEntity> InsertAsync(TEntity entity)
        {
            return this._db.Insertable<TEntity>(entity).ExecuteReturnEntityAsync();
        }

        #endregion

        #region 自定义扩展方法

        /// <summary>
        /// 可查询接口，不建议直接使用
        /// </summary>
        /// <returns></returns>
        public ISugarQueryable<TEntity> Queryable()
        {
            return this._db.Queryable<TEntity>();
        }

        //public  int Update(TEntity entity)
        //{
        //    return this._db.Updateable<TEntity>(entity).ExecuteCommand();
        //}

        //public  Task<int> UpdateAsync(TEntity entity)
        //{
        //    return this._db.Updateable<TEntity>(entity).ExecuteCommandAsync();
        //}

        /// <summary>
        /// 根据主键假删除
        /// </summary>
        /// <param name="id"></param>
        public override void SoftDelete(TPrimaryKey id)
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                var tablename = this.GetTableName();//获取表名
                var pkcolumnname = this.GetPrimaryKeys();//获取主键列名
                if (pkcolumnname == null || pkcolumnname.Count < 1)
                {
                    throw new Exception($"{this.GetTableName()}表没有设置主键!");
                }
                else if (pkcolumnname.Count > 1)
                {
                    throw new Exception($"{nameof(ISoftDelete)}不支持联合主键删除!");
                }

                string sql = $"update {tablename} set {nameof(ISoftDelete.IsDeleted)}=@IsDeleted where {pkcolumnname[0]}=@id";
                _db.Ado.ExecuteCommand(sql, new { id = id, IsDeleted = true });
            }
            else
            {
                throw new Exception($"{typeof(TEntity).Name}实体类没有继承{nameof(ISoftDelete)},不允许假删除");
            }
        }

        /// <summary>
        /// 获取主键列名信息
        /// </summary>
        /// <returns></returns>
        protected List<string> GetPrimaryKeys()
        {
            if (this._db.Context.IsSystemTablesConfig)
            {
                return this._db.DbMaintenance.GetPrimaries(this.GetTableName());
            }
            else
            {
                return _db.EntityMaintenance.GetEntityInfo<TEntity>().Columns.Where(it => it.IsPrimarykey).Select(it => it.DbColumnName).ToList();
            }
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        protected string GetTableName()
        {
            return this._db.EntityMaintenance.GetEntityInfo<TEntity>().DbTableName;
        }

        #endregion

        public override ISugarQueryable<TEntity> GetAll()
        {
            return _db.Queryable<TEntity>();
        }

        public override TEntity Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
