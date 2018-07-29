using System;
using System.Collections.Generic;

namespace tcl.RepositoryExtend
{
    public interface IRepositoryFilters
    {
        /// <summary>
        /// 获取拦截器列表副本(并能够追加其他拦截器列表),默认禁止自动追加必要的仓储层过滤器,若要自动追加必要的仓储层过滤器，请先使用SetAppendMustFilter方法设置
        /// </summary>
        /// <typeparam name="Tout">输出类型,用于自动追加必要的仓储层过滤器</typeparam>
        /// <param name="filters"></param>
        /// <returns></returns>
        List<IRepositoryFilter> GetFilters<Tout>(params IRepositoryFilter[] filters);

    }

    public interface IRepositoryFilters<T>: IRepositoryFilters
    {
        /// <summary>
        /// 设置仓储过滤器
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        T SetFilters(params IRepositoryFilter[] filters);

        /// <summary>
        /// 设置是否允许自动追加必要的仓储层过滤器
        /// </summary>
        T SetAppendMustFilter(bool isAllowAutoAppendMustFilter);
    }
}
