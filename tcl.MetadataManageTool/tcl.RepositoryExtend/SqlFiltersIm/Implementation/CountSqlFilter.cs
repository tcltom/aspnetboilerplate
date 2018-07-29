using System;
using System.Collections.Generic;
using System.Text;

namespace tcl.RepositoryExtend
{
    /// <summary>
    /// 查询数据条数的sql过滤器
    /// </summary>
    public class CountSqlFilter : ISqlFilter
    {
        public SqlParamInfo Run(SqlParamInfo info)
        {
            info.Sql = $"select count(*) from ({info.Sql}) v ";
            return info;
        }
    }
}
