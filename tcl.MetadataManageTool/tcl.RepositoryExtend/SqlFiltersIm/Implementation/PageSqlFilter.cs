using System;
using System.Collections.Generic;
using System.Text;

namespace tcl.RepositoryExtend
{
    /// <summary>
    /// 查询分页数据的sql过滤器
    /// </summary>
    public class PageSqlFilter : IPageSqlFilter
    {
        public IPageInfo PageInfo { get; set; }

        public string OrderSql { get; set; }

        public string DataType { get; set; }

        public PageSqlFilter(string dataType, IPageInfo pageInfo,string orderSql)
        {
            this.DataType = dataType;
            this.PageInfo = pageInfo;
            this.OrderSql = orderSql;
        }

        public SqlParamInfo Run(SqlParamInfo info)
        {
            if (this.DataType.ToLower() ==DbType.MySql.ToLower())
            {
                info.Sql = info.Sql.Replace("limit", "").Replace("@SkipNum,@PageSize", "").Replace("@SkipNum", "").Replace("@PageSize", "");//替换掉原有分页参数
                if (!string.IsNullOrWhiteSpace(OrderSql))
                {
                    info.Sql = $"select * from ({info.Sql}) v order by {OrderSql} limit @sqlfilter_SkipNum,@sqlfilter_PageSize ";
                }
                else
                {
                    info.Sql = $"select * from ({info.Sql}) v  limit @sqlfilter_SkipNum,@sqlfilter_PageSize ";
                }

                ////注意针对追加的参数，定义参数名要以sqlfilter_作为前缀，避免和其他参数同名
                info.AddParam("sqlfilter_PageSize", this.PageInfo.PageSize);
                info.AddParam("sqlfilter_SkipNum", this.PageInfo.SkipNum);
            }
            else if (this.DataType.ToLower() == DbType.SqlServer.ToLower())
            {
                if (!string.IsNullOrWhiteSpace(OrderSql))
                {
                    info.Sql = $"select * FROM (SELECT *,ROW_NUMBER() OVER( ORDER BY {OrderSql} ) AS RowIndex FROM ({info.Sql}) v) v WHERE RowIndex BETWEEN @sqlfilter_StartRowIndex AND @sqlfilter_EndRowIndex";
                }
                else
                {
                    info.Sql = $"select * FROM (SELECT *,ROW_NUMBER() OVER( ORDER BY GetDate() ) AS RowIndex FROM ({info.Sql}) v) v WHERE RowIndex BETWEEN @sqlfilter_StartRowIndex AND @sqlfilter_EndRowIndex";
                }

                ////注意针对追加的参数，定义参数名要以sqlfilter_作为前缀，避免和其他参数同名
                info.AddParam("sqlfilter_StartRowIndex", this.PageInfo.StartRowIndex);
                info.AddParam("sqlfilter_EndRowIndex", this.PageInfo.EndRowIndex);
            }
            else
            {
                throw new Exception($"{nameof(PageSqlFilter)}目前不支持{this.DataType}类型的数据库");
            }

            return info;
        }
    }
}
