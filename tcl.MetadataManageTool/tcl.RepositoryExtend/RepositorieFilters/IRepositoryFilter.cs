using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    public interface IRepositoryFilter
    {
        /// <summary>
        /// 获取sql过滤器列表
        /// </summary>
        List<ISqlFilter> GetSqlFilters();

        /// <summary>
        /// 添加sql过滤器
        /// </summary>
        /// <param name="sqlFilters">sql过滤器列表</param>
        IRepositoryFilter AddSqlFilters(params ISqlFilter[] sqlFilters);
    }
}
