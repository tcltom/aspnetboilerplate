using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    public static class RepositoryHelper
    {
        /// <summary>
        /// 是否相等类型(可能以后的匹配规则要改变，所以提供了一个新的判断匹配的方法)
        /// </summary>
        /// <param name="type1"></param>
        /// <param name="type2"></param>
        /// <returns></returns>
        public static bool EqualType(this Type type1, Type type2)
        {
            if (type1 == type2)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 匹配类型(可能以后的匹配规则要改变，所以提供了一个新的判断匹配的方法)
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static bool MatchType<T1, T2>()
        {
            return EqualType(typeof(T1), typeof(T2));
        }

        /// <summary>
        /// 转换数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T ConvertValue<T>(dynamic data)
        {
            return (T)Convert.ChangeType(data, typeof(T));
        }

        /// <summary>
        /// 获取sql参数信息
        /// </summary>
        /// <param name="sqlinfo">源sql信息</param>
        /// <param name="RepositoryFilters">仓储层过滤器</param>
        /// <returns></returns>
        public static SqlParamInfo RunSqlFilters(SqlParamInfo sqlinfo, params IRepositoryFilter[] RepositoryFilters)
        {
            return RunSqlFilters(RepositoryFilters, sqlinfo);
        }

        /// <summary>
        /// 获取sql参数信息
        /// </summary>
        /// <param name="sql">源sql</param>
        /// <param name="param">源sql参数</param>
        /// <param name="SqlFilters">sql过滤器</param>
        /// <returns></returns>
        public static SqlParamInfo RunSqlFilters(string sql, object param, params ISqlFilter[] SqlFilters)
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, param);
            return RunSqlFilters(sqlinfo, SqlFilters);
        }

        /// <summary>
        /// 获取sql参数信息
        /// </summary>
        /// <param name="sql">源sql</param>
        /// <param name="param">源sql参数</param>
        /// <param name="SqlFilters">sql过滤器</param>
        /// <returns></returns>
        public static SqlParamInfo RunSqlFilters(SqlParamInfo sqlinfo, params ISqlFilter[] SqlFilters)
        {
            return RunSqlFilters(SqlFilters, sqlinfo);
        }

        /// <summary>
        /// 获取sql参数信息
        /// </summary>
        /// <param name="SqlFilters">sql过滤器</param>
        /// <param name="sqlinfo">源sql信息</param>
        /// <returns></returns>
        public static SqlParamInfo RunSqlFilters(IEnumerable<ISqlFilter> SqlFilters, string sql, object param)
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, param);
            return RunSqlFilters(SqlFilters, sqlinfo);
        }

        /// <summary>
        /// 获取sql参数信息
        /// </summary>
        /// <param name="SqlFilters">sql过滤器</param>
        /// <param name="sqlinfo">源sql信息</param>
        /// <returns></returns>
        public static SqlParamInfo RunSqlFilters(IEnumerable<ISqlFilter> SqlFilters, SqlParamInfo sqlinfo)
        {
            if (SqlFilters != null && SqlFilters.Count() > 0)
            {
                foreach (var sqlfilter in SqlFilters)
                {
                    sqlinfo = sqlfilter.Run(sqlinfo);
                }
            }

            return sqlinfo;
        }

        /// <summary>
        /// 获取sql参数信息
        /// </summary>
        /// <param name="sql">源sql</param>
        /// <param name="param">源sql参数</param>
        /// <param name="RepositoryFilters">仓储层过滤器</param>
        /// <returns></returns>
        public static SqlParamInfo RunSqlFilters(string sql, object param, params IRepositoryFilter[] RepositoryFilters)
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, param);
            return RunSqlFilters(sqlinfo, RepositoryFilters);
        }

        /// <summary>
        /// 执行sql过滤器
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SqlParamInfo RunSqlFilters(IEnumerable<IRepositoryFilter> filters, string sql, object param)
        {
            SqlParamInfo sqlinfo = new SqlParamInfo(sql, param);
            return RunSqlFilters(filters, sqlinfo);
        }

        /// <summary>
        /// 执行sql过滤器
        /// </summary>
        /// <param name="sqlparam"></param>
        /// <returns></returns>
        public static SqlParamInfo RunSqlFilters(IEnumerable<IRepositoryFilter> RepositoryFilters, SqlParamInfo sqlinfo)
        {
            if (RepositoryFilters != null && RepositoryFilters.Count() > 0)
            {
                foreach (var filter in RepositoryFilters)
                {
                    var sqlFilters = filter.GetSqlFilters();
                    sqlinfo = RunSqlFilters(sqlFilters, sqlinfo);
                }
            }

            return sqlinfo;
        }
    }
}
