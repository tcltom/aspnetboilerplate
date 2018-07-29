using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    /// <summary>
    /// 注意，因为存在多种过滤器时，部分过滤器并非必须实现,所以用基类先实现，目前只定义了sql过滤器,可能还包含其他过滤器，比如列过滤器,行过滤器,返回值过滤器等
    /// </summary>
    public class RepositoryFilter : IRepositoryFilter
    {
        private List<ISqlFilter> _SqlFilters = new List<ISqlFilter>();

        public RepositoryFilter()
        {

        }

        public RepositoryFilter(params ISqlFilter[] sqlFilters)
        {
            this.AddSqlFilters(sqlFilters);
        }

        /// <summary>
        /// 添加sql过滤器
        /// </summary>
        /// <param name="sqlFilters">sql过滤器列表</param>
        public IRepositoryFilter AddSqlFilters(params ISqlFilter[] sqlFilters)
        {
            if (sqlFilters != null && sqlFilters.Length > 0)
            {
                _SqlFilters.AddRange(sqlFilters);
            }

            return this;
        }

        /// <summary>
        /// 获取sql过滤器列表
        /// </summary>
        /// <returns></returns>
        public List<ISqlFilter> GetSqlFilters()
        {
            return _SqlFilters.ToList();//注意获取副本，避免数据污染
        }
    }
}

