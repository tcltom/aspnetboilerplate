using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    public class RepositoryFilters<T> : IRepositoryFilters<T> where T : class,IRepositoryFilters<T>
    {
        /// <summary>
        /// 注意不建议返回属性Filters，用Get方法进行返回，可以避免误操作导致的数据污染
        /// </summary>
        private List<IRepositoryFilter> _Filters { get; set; } = new List<IRepositoryFilter>();

        /// <summary>
        /// 是否允许自动追加必要的仓储层过滤器,默认禁止自动追加
        /// </summary>
        private bool IsAllowAutoAppendMustFilter { get; set; } = false;

        /// <summary>
        /// 设置仓储过滤器（设置前自动清空原有仓储过滤器列表）
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public T SetFilters(params IRepositoryFilter[] filters)
        {
            this._Filters.Clear();
            if (filters != null && filters.Length > 0)
            {
                this._Filters.AddRange(filters);
            }

            return this as T;
        }

        /// <summary>
        /// 获取拦截器列表副本(并能够追加其他拦截器列表),默认禁止自动追加必要的仓储层过滤器,若要自动追加必要的仓储层过滤器，请先使用SetAppendMustFilter方法设置
        /// </summary>
        /// <typeparam name="Tout">输出类型,用于自动追加必要的仓储层过滤器</typeparam>
        /// <param name="filters">追加的过滤器</param>
        /// <returns></returns>
        public List<IRepositoryFilter> GetFilters<Tout>(params IRepositoryFilter[] filters)
        {
            var temFilters = this._Filters.ToList();//注意返回其副本，避免数据污染

            ////注意此方法应该在追加的仓储层过滤器前面,例如：count过滤器一定要放在最后
            if (this.IsAllowAutoAppendMustFilter)
            {
                AutoAppendMustRepositoryFilter<Tout>(temFilters);//追加必要的仓储层过滤器
            }

            if (filters != null && filters.Length > 0)
            {
                temFilters.AddRange(filters);////注意此方法应该在追加的必要的仓储层过滤器后面
            }

            return temFilters;
        }

        /// <summary>
        /// 设置是否允许自动追加必要的仓储层过滤器
        /// </summary>
        public T SetAppendMustFilter(bool isAllowAutoAppendMustFilter)
        {
            this.IsAllowAutoAppendMustFilter = isAllowAutoAppendMustFilter;
            return this as T;
        }

        /// <summary>
        /// 追加必要的仓储层过滤器
        /// </summary>
        private void AutoAppendMustRepositoryFilter<TOut>(List<IRepositoryFilter> filters)
        {
            if (typeof(IMustHaveTenant).IsAssignableFrom(typeof(TOut)) && this is IMayHaveTenant)//添加查询所属租户的sql过滤器
            {
                var tenant = this as IMayHaveTenant;
                filters.Add(new RepositoryFilter(new QueryMustHaveTenantSqlFilter(tenant.TenantId)));
            }

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TOut)))//添加查询非删除数据的sql过滤器
            {
                filters.Add(new RepositoryFilter(new QueryNoDeleteSqlFilter()));
            }
        }
    }
}
