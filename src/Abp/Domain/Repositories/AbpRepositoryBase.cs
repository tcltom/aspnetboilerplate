using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Reflection.Extensions;
using SqlSugar;

namespace Abp.Domain.Repositories
{
    /// <summary>
    /// Base class to implement <see cref="IRepository{TEntity,TPrimaryKey}"/>.
    /// It implements some methods in most simple way.
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity for this repository</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key of the entity</typeparam>
    public abstract class AbpRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        /// <summary>
        /// The multi tenancy side
        /// </summary>
        public static MultiTenancySides? MultiTenancySide { get; private set; }

        public IUnitOfWorkManager UnitOfWorkManager { get; set; }

        public IIocResolver IocResolver { get; set; }

        static AbpRepositoryBase()
        {
            var attr = typeof(TEntity).GetSingleAttributeOfTypeOrBaseTypesOrNull<MultiTenancySideAttribute>();
            if (attr != null)
            {
                MultiTenancySide = attr.Side;
            }
        }

        public abstract ISugarQueryable<TEntity> GetAll();

        public virtual ISugarQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return GetAll();
        }

        public virtual List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        public virtual Task<List<TEntity>> GetAllListAsync()
        {
            return Task.FromResult(GetAllList());
        }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(GetAllList(predicate));
        }

        public virtual T Query<T>(Func<ISugarQueryable<TEntity>, T> queryMethod)
        {
            return queryMethod(GetAll());
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            var entity = FirstOrDefault(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            return entity;
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            var entity = await FirstOrDefaultAsync(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            return entity;
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Single(predicate);
        }

        public virtual Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Single(predicate));
        }

        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().First(CreateEqualityExpressionForId(id));
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return Task.FromResult(FirstOrDefault(id));
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().First(predicate);
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(FirstOrDefault(predicate));
        }

        public virtual TEntity Load(TPrimaryKey id)
        {
            return Get(id);
        }

        public abstract TEntity Insert(TEntity entity);

        public virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        public virtual TPrimaryKey InsertAndGetId(TEntity entity)
        {
            var model = Insert(entity);
            return GetId(model);
        }

        public virtual Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            return Task.FromResult(InsertAndGetId(entity));
        }

        public virtual TEntity InsertOrUpdate(TEntity entity)
        {
            return IsTransient(entity)
                ? Insert(entity)
                : Update(entity);
        }

        public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return IsTransient(entity)
                ? await InsertAsync(entity)
                : await UpdateAsync(entity);
        }

        public virtual TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            return GetId(InsertOrUpdate(entity));
        }

        public virtual Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            return Task.FromResult(InsertOrUpdateAndGetId(entity));
        }

        public abstract TEntity Update(TEntity entity);

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        public virtual TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            var entity = Get(id);
            updateAction(entity);
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            var entity = await GetAsync(id);
            await updateAction(entity);
            return entity;
        }

        public abstract void Delete(TEntity entity);

        public virtual Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }

        public abstract void Delete(TPrimaryKey id);

        public virtual Task DeleteAsync(TPrimaryKey id)
        {
            Delete(id);
            return Task.FromResult(0);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }

        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
            return Task.FromResult(0);
        }

        public virtual int Count()
        {
            return GetAll().Count();
        }

        public virtual Task<int> CountAsync()
        {
            return Task.FromResult(Count());
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Count(predicate));
        }

        public virtual long LongCount()
        {
            return GetAll().Count();
        }

        public virtual Task<long> LongCountAsync()
        {
            return Task.FromResult(LongCount());
        }

        public virtual long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        public virtual Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(LongCount(predicate));
        }

        protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        /// <summary>
        /// 根据主键假删除
        /// </summary>
        /// <param name="id"></param>
        public virtual void SoftDelete(TPrimaryKey id)
        {

        }

        /// <summary>
        /// 获取主键列名信息
        /// </summary>
        /// <returns></returns>
        protected string GetPrimaryKey(ISugarQueryable<TEntity> query)
        {
            var pkcolumnname = this.GetPrimaryKeys(query);//获取主键列名
            if (pkcolumnname == null || pkcolumnname.Count < 1)
            {
                throw new Exception($"{this.GetTableName(query)}表没有设置主键!");
            }
            else if (pkcolumnname.Count > 1)
            {
                throw new Exception($"不支持联合主键删除!");
            }

            return pkcolumnname[0];
        }

        /// <summary>
        /// 获取主键列名信息
        /// </summary>
        /// <returns></returns>
        protected List<string> GetPrimaryKeys(ISugarQueryable<TEntity> query)
        {
            if (query.Context.IsSystemTablesConfig)
            {
                return query.Context.DbMaintenance.GetPrimaries(this.GetTableName(query));
            }
            else
            {
                return query.Context.EntityMaintenance.GetEntityInfo<TEntity>().Columns.Where(it => it.IsPrimarykey).Select(it => it.DbColumnName).ToList();
            }
        }

        /// <summary>
        /// 获取主键列属性信息
        /// </summary>
        /// <returns></returns>
        protected PropertyInfo GetPrimaryProperty(ISugarQueryable<TEntity> query)
        {
            var pkproinfo = this.GetPrimaryPropertys(query);//获取主键列名
            if (pkproinfo == null || pkproinfo.Count < 1)
            {
                throw new Exception($"{this.GetTableName(query)}表没有设置主键!");
            }
            else if (pkproinfo.Count > 1)
            {
                throw new Exception($"不支持联合主键删除!");
            }

            return pkproinfo[0];
        }

        /// <summary>
        /// 获取主键列属性信息
        /// </summary>
        /// <returns></returns>
        protected List<PropertyInfo> GetPrimaryPropertys(ISugarQueryable<TEntity> query)
        {
            return query.Context.EntityMaintenance.GetEntityInfo<TEntity>().Columns.Where(it => it.IsPrimarykey).Select(it => it.PropertyInfo).ToList();
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        protected string GetTableName(ISugarQueryable<TEntity> query)
        {
            return query.Context.EntityMaintenance.GetEntityInfo<TEntity>().DbTableName;
        }

        protected bool IsTransient(TEntity entity)
        {
            var Id = GetId(entity);
            if (EqualityComparer<TPrimaryKey>.Default.Equals(Id, default(TPrimaryKey)))
            {
                return true;
            }

            if (typeof(TPrimaryKey) == typeof(int))
            {
                return Convert.ToInt32(Id) <= 0;
            }

            if (typeof(TPrimaryKey) == typeof(long))
            {
                return Convert.ToInt64(Id) <= 0;
            }

            return false;
        }

        protected TPrimaryKey GetId(TEntity entity)
        {
            var Id = (TPrimaryKey)GetPrimaryProperty(GetAll()).GetValue(entity);
            return Id;
        }
    }
}
