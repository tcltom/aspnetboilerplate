using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    /// <summary>
    /// 查询非删除数据的sql过滤器
    /// </summary>
    public class QueryNoDeleteSqlFilter : ISqlFilter
    {
        public SqlParamInfo Run(SqlParamInfo info)
        {
            info.Sql = $"select * from ({info.Sql}) v  where v.{nameof(ISoftDelete.IsDeleted)}=@sqlfilter_IsDeleted";
            info.AddParam("sqlfilter_IsDeleted", false);//注意针对追加的参数，定义参数名要以sqlfilter_作为前缀，避免和其他参数同名
            return info;
        }
    }
}
