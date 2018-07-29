using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using SqlSugar;

namespace Abp.SqlSugarCore.Repositories
{
    /// <summary>
    ///     SqlSugarCore repository abstraction interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TPrimaryKey">The type of the primary key.</typeparam>
    /// <seealso cref="ISqlSugarCoreRepository{TEntity,TPrimaryKey}" />
    public interface ISqlSugarCoreRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>, ITransientDependency where TEntity : class
    {
        //#region 从abp默认接口IRepository<TEntity, TPrimaryKey>中拷贝过来
        ////
        //// 摘要:
        ////     Gets count of all entities in this repository.
        ////
        //// 返回结果:
        ////     Count of entities
        //int Count();

        ////
        //// 摘要:
        ////     Gets count of all entities in this repository.
        ////
        //// 返回结果:
        ////     Count of entities
        //Task<int> CountAsync();
        ////
        //// 摘要:
        ////     Deletes an entity.
        ////
        //// 参数:
        ////   entity:
        ////     Entity to be deleted
        //void Delete(TEntity entity);
        ////
        //// 摘要:
        ////     Deletes an entity by primary key.
        ////
        //// 参数:
        ////   id:
        ////     Primary key of the entity
        //void Delete(TPrimaryKey id);

        ////
        //// 摘要:
        ////     Deletes an entity by primary key.
        ////
        //// 参数:
        ////   id:
        ////     Primary key of the entity
        //Task DeleteAsync(TPrimaryKey id);

        ////
        //// 摘要:
        ////     Deletes an entity.
        ////
        //// 参数:
        ////   entity:
        ////     Entity to be deleted
        //Task DeleteAsync(TEntity entity);

        ////
        //// 摘要:
        ////     Gets an entity with given primary key or null if not found.
        ////
        //// 参数:
        ////   id:
        ////     Primary key of the entity to get
        ////
        //// 返回结果:
        ////     Entity or null
        //TEntity FirstOrDefault(TPrimaryKey id);

        ////
        //// 摘要:
        ////     Gets an entity with given primary key or null if not found.
        ////
        //// 参数:
        ////   id:
        ////     Primary key of the entity to get
        ////
        //// 返回结果:
        ////     Entity or null
        //Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
        ////
        //// 摘要:
        ////     Gets an entity with given primary key.
        ////
        //// 参数:
        ////   id:
        ////     Primary key of the entity to get
        ////
        //// 返回结果:
        ////     Entity
        //TEntity Get(TPrimaryKey id);

        ////
        //// 摘要:
        ////     Used to get all entities.
        ////
        //// 返回结果:
        ////     List of all entities
        //List<TEntity> GetAllList();

        ////
        //// 摘要:
        ////     Used to get all entities.
        ////
        //// 返回结果:
        ////     List of all entities
        //Task<List<TEntity>> GetAllListAsync();
        ////
        //// 摘要:
        ////     Gets an entity with given primary key.
        ////
        //// 参数:
        ////   id:
        ////     Primary key of the entity to get
        ////
        //// 返回结果:
        ////     Entity
        //Task<TEntity> GetAsync(TPrimaryKey id);
        ////
        //// 摘要:
        ////     Inserts a new entity.
        ////
        //// 参数:
        ////   entity:
        ////     Inserted entity
        //TEntity Insert(TEntity entity);

        //#endregion

        #region 自定义扩展方法

        /// <summary>
        /// 可查询接口，不建议直接使用
        /// </summary>
        /// <returns></returns>
        ISugarQueryable<TEntity> Queryable();

        #endregion
    }
}
