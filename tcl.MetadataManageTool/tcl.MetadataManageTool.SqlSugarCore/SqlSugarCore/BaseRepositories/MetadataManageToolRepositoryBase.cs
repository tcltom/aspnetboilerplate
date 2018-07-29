using Abp.SqlSugarCore.Repositories;
using ImpromptuInterface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Dynamic;
using tcl.RepositoryExtend;
using tcl.RepositoryExtend.Repository;

namespace tcl.MetadataManageTool.SqlSugarCore.Repositories
{

    /// <summary>
    /// 仓储基类,默认实现接口，所有仓储类继承它，避免仓储类的非必要实现,也为了方便后期扩展
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <typeparam name="TSave"></typeparam>
    /// <typeparam name="TQuery"></typeparam>
    ///  <typeparam name="TPrimaryKey"></typeparam>
    public class MetadataManageToolRepositoryBase<TEntity, TOut, TSave, TQuery, TPrimaryKey> : SqlSugarCoreRepositoryBase<TEntity, TPrimaryKey> where TEntity : class, new()
    {
        private SqlSugarClient _db;

        public MetadataManageToolRepositoryBase(SqlSugarClient db) : base(db)
        {
            this._db = db;
        }

        /// <summary>
        /// 动态实现接口
        /// </summary>
        /// <typeparam name="TGroupRepository"></typeparam>
        /// <returns></returns>
        protected dynamic CreateInterface<TGroupRepository>() where TGroupRepository : IGroupRepository
        {
            dynamic expando = new ExpandoObject();
            var dic = (IDictionary<string, object>)expando;
            var type = typeof(TGroupRepository);
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                if (typeof(IGetRepository).IsAssignableFrom(type))
                {
                    dic[method.Name] = new Func<TQuery, TOut>(query => this.Get(method.Name, query));
                }
                else if (typeof(IGetListRepository).IsAssignableFrom(type))
                {
                    dic[method.Name] = new Func<TQuery, List<TOut>>(query => this.GetList(method.Name, query));
                }
                else if (typeof(IGetPageListRepository).IsAssignableFrom(type))
                {
                    dic[method.Name] = new Func<TQuery, PageList<TOut>>(query => this.GetPageList(method.Name, query));
                }
                else if (typeof(IQueryRepository).IsAssignableFrom(type))
                {
                    dic[method.Name] = new Func<TQuery, object>(query => this.Query(method.Name, query));
                }
                else if (typeof(ICountRepository).IsAssignableFrom(type))
                {
                    dic[method.Name] = new Func<TQuery, int>(query => this.Count(method.Name, query));
                }
                else if (typeof(IExistRepository).IsAssignableFrom(type))
                {
                    dic[method.Name] = new Func<TQuery, bool>(query => this.Exist(method.Name, query));
                }
                else if (typeof(ISaveRepository).IsAssignableFrom(type))
                {
                    dic[method.Name] = new Action<TSave>(query => this.Save(method.Name, query));
                }
            }

            var ret = Impromptu.ActLike(expando);
            return ret;
        }

        protected virtual int Count(string methodName, TQuery data)
        {
            throw new Exception(GetExceptionMessage(nameof(Count), methodName));
        }

        protected virtual bool Exist(string methodName, TQuery data)
        {
            throw new Exception(GetExceptionMessage(nameof(Exist), methodName));
        }

        protected virtual TOut Get(string methodName, TQuery data)
        {
            throw new Exception(GetExceptionMessage(nameof(Get), methodName));
        }

        protected virtual List<TOut> GetList(string methodName, TQuery data)
        {
            throw new Exception(GetExceptionMessage(nameof(GetList), methodName));
        }


        protected virtual PageList<TOut> GetPageList(string methodName, TQuery data)
        {
            throw new Exception(GetExceptionMessage(nameof(GetPageList), methodName));
        }

        protected virtual object Query(string methodName, TQuery data)
        {
            throw new Exception(GetExceptionMessage(nameof(Query), methodName));
        }

        protected virtual void Save(string methodName, TSave data)
        {
            throw new Exception(GetExceptionMessage(nameof(Save), methodName));
        }

        private string GetExceptionMessage(string methodGroupName, string methodName)
        {
            return $"未在{GetThisName()}类中的{methodGroupName}方法中实现方法名为{methodName}的逻辑";
        }

        private string GetThisName()
        {
            return this.GetType().BaseType.Name;
        }
    }
}
