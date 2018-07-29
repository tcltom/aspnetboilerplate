using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    /// <summary>
    /// 查询所属租户的数据的sql过滤器
    /// </summary>
    public class QueryMustHaveTenantSqlFilter : ISqlFilter
    {
        public int? TenantId { get; set; }


        public QueryMustHaveTenantSqlFilter(int? tenantId)
        {
            this.TenantId = tenantId;
        }

        public SqlParamInfo Run(SqlParamInfo info)
        {
            info.Sql = $"select * from ({info.Sql}) v  where v.{nameof(IMustHaveTenant.TenantId)}=@sqlfilter_TenantId";
            info.AddParam("sqlfilter_TenantId", this.TenantId);//注意针对追加的参数，定义参数名要以sqlfilter_作为前缀，避免和其他参数同名
            return info;
        }
    }
}
