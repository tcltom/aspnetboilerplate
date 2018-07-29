using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcl.RepositoryExtend;
using tcl.SqlSugarExtend.Helper;
using tcl.SqlSugarExtend.Models;

namespace tcl.SqlSugarExtend
{
    public static class IAdoExtend
    {
        public static List<T> SqlQuery<T>(this IAdo ado, SqlParamInfo sqlparam)
        {
            var sugarParameter = sqlparam.ConvertToSugarParameter();
            return ado.SqlQuery<T>(sugarParameter.Key, sugarParameter.Value);
        }

        public static T SqlQuerySingle<T>(this IAdo ado, SqlParamInfo sqlparam)
        {
            var sugarParameter = sqlparam.ConvertToSugarParameter();
            return ado.SqlQuerySingle<T>(sugarParameter.Key, sugarParameter.Value);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="sql"></param>
        /// <param name="repositoryFilters">带过滤器的参数</param>
        /// <returns></returns>
        public static T QueryFirst<T>(this IAdo ado, string sql, IRepositoryFilters repositoryFilters)
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, repositoryFilters);
            return QueryFirst<T>(ado, repositoryFilters.GetFilters<T>(), sqlinfo);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="filters"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QueryFirst<T>(this IAdo ado, List<IRepositoryFilter> filters, string sql, object param)
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, param);
            return QueryFirst<T>(ado, filters, sqlinfo);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="Filters"></param>
        /// <param name="sqlinfo"></param>
        /// <returns></returns>
        public static T QueryFirst<T>(this IAdo ado, List<IRepositoryFilter> filters, SqlParamInfo sqlinfo)
        {
            sqlinfo = RepositoryHelper.RunSqlFilters(filters, sqlinfo);
            return ado.SqlQuerySingle<T>(sqlinfo);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="sql"></param>
        /// <param name="repositoryFilters">带过滤器的参数</param>
        /// <returns></returns>
        public static List<T> GetList<T>(this IAdo ado, string sql, IRepositoryFilters repositoryFilters)
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, repositoryFilters);
            return GetList<T>(ado, repositoryFilters.GetFilters<T>(), sqlinfo);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="filters"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(this IAdo ado, List<IRepositoryFilter> filters, string sql, object param)
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, param);
            return GetList<T>(ado, filters, sqlinfo);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="filters"></param>
        /// <param name="sqlinfo"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(this IAdo ado, List<IRepositoryFilter> filters, SqlParamInfo sqlinfo)
        {
            sqlinfo = RepositoryHelper.RunSqlFilters(filters, sqlinfo);
            return ado.SqlQuery<T>(sqlinfo);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="sql"></param>
        /// <param name="repositoryFilters">带过滤器的参数</param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static PageList<T> GetPageList<T>(this IAdo ado, string sql, IRepositoryFilters repositoryFilters, string orderby = "")
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, repositoryFilters);
            IPageInfo pageinfo = repositoryFilters as IPageInfo;
            if (pageinfo == null)
            {
                throw new Exception($"参数{nameof(repositoryFilters)}应该继承{nameof(IPageInfo)}接口");
            }

            return GetPageList<T>(ado, repositoryFilters.GetFilters<T>(), sqlinfo, pageinfo, orderby);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="sql"></param>
        /// <param name="repositoryFilters">带过滤器的参数</param>
        /// <param name="orderbyExpression"></param>
        /// <returns></returns>
        public static PageList<T> GetPageList<T>(this IAdo ado, string sql, IRepositoryFilters repositoryFilters, params System.Linq.Expressions.Expression<Func<T, IOrderBy>>[] orderbyExpression)
        {
            return GetPageList<T>(ado, sql, repositoryFilters, ExpressionHelper.ConvertToString(orderbyExpression));
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="filters"></param>
        /// <param name="sql"></param>
        /// <param name="pageInfo"></param>
        /// <param name="orderbyExpression"></param>
        /// <returns></returns>
        public static PageList<T> GetPageList<T>(this IAdo ado, List<IRepositoryFilter> filters, string sql, IPageInfo pageInfo, params System.Linq.Expressions.Expression<Func<T, IOrderBy>>[] orderbyExpression)
        {
            return GetPageList<T>(ado, filters, sql, pageInfo, ExpressionHelper.ConvertToString(orderbyExpression));
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="filters"></param>
        /// <param name="sql"></param>
        /// <param name="pageInfo"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static PageList<T> GetPageList<T>(this IAdo ado, List<IRepositoryFilter> filters, string sql, IPageInfo pageInfo, string orderby = "")
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, pageInfo);
            return GetPageList<T>(ado, filters, sqlinfo, pageInfo, orderby);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="filters"></param>
        /// <param name="sqlinfo"></param>
        /// <param name="pageinfo"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static PageList<T> GetPageList<T>(this IAdo ado, List<IRepositoryFilter> filters, SqlParamInfo sqlinfo, IPageInfo pageinfo, string orderby = "")
        {
            var rowfilters = filters.ToList();
            rowfilters.Add(new RepositoryFilter(new PageSqlFilter(ado.Context.CurrentConnectionConfig.DbType.ToString(), pageinfo, orderby)));//分页拦截器
            var countfilters = filters.ToList();
            countfilters.Add(new RepositoryFilter(new CountSqlFilter()));//总数拦截器
            var rowsqlinfo = RepositoryHelper.RunSqlFilters(rowfilters, sqlinfo.Copy());//注意用副本参数,避免对象共享
            var countsqlinfo = RepositoryHelper.RunSqlFilters(countfilters, sqlinfo.Copy());//注意用副本参数,避免对象共享
            var listdata = ado.SqlQuery<T>(rowsqlinfo);
            var count = ado.SqlQuerySingle<int>(countsqlinfo);
            return new PageList<T>(listdata, count);
        }

        /// <summary>
        /// 执行sql过滤器并返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ado"></param>
        /// <param name="filters"></param>
        /// <param name="sqlinfo"></param>
        /// <param name="pageinfo"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static PageList<T> GetPageList<T>(this IAdo ado, List<IRepositoryFilter> filters, SqlParamInfo sqlinfo, IPageInfo pageinfo, params System.Linq.Expressions.Expression<Func<T, IOrderBy>>[] orderbyExpression)
        {
            return GetPageList<T>(ado, filters, sqlinfo, pageinfo, ExpressionHelper.ConvertToString(orderbyExpression));
        }
    }
}
