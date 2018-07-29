using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tcl.RepositoryExtend;
using tcl.SqlSugarExtend.Helper;
using tcl.SqlSugarExtend.Models;

namespace tcl.SqlSugarExtend
{
    public static class QueryableExtend
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sugarQueryable"></param>
        /// <param name="param">带过滤器的参数</param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static PageList<T> ToPageList<T>(this ISugarQueryable<T> sugarQueryable, IRepositoryFilters param, string orderby = "")
        {
            var sugarParameter = sugarQueryable.ToSql();
            var sqlinfo = new SqlParamInfo(sugarParameter.Key, sugarParameter.Value);
            IPageInfo pageinfo = param as IPageInfo;
            if (pageinfo == null)
            {
                throw new Exception($"参数{nameof(param)}应该继承{nameof(IPageInfo)}接口");
            }

            var pagedata = sugarQueryable.Context.Ado.GetPageList<T>(param.GetFilters<T>(), sqlinfo, pageinfo, orderby);
            return pagedata;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sugarQueryable"></param>
        /// <param name="param">带过滤器的参数</param>
        /// <param name="orderbyExpression"></param>
        /// <returns></returns>
        public static PageList<T> ToPageList<T>(this ISugarQueryable<T> sugarQueryable, IRepositoryFilters param, params System.Linq.Expressions.Expression<Func<T, IOrderBy>>[] orderbyExpression)
        {
            return ToPageList<T>(sugarQueryable, param, ExpressionHelper.ConvertToString(orderbyExpression));
        }

        public static PageList<T> ToPageList<T>(this ISugarQueryable<T> sugarQueryable, List<IRepositoryFilter> listfilter, IPageInfo pageInfo, string orderby = "")
        {
            var sugarParameter = sugarQueryable.ToSql();
            var sqlinfo = new SqlParamInfo(sugarParameter.Key, sugarParameter.Value);
            var pagedata = sugarQueryable.Context.Ado.GetPageList<T>(listfilter, sqlinfo, pageInfo, orderby);
            return pagedata;
        }

        public static PageList<T> ToPageList<T>(this ISugarQueryable<T> sugarQueryable, List<IRepositoryFilter> listfilter, IPageInfo pageInfo, params System.Linq.Expressions.Expression<Func<T, IOrderBy>>[] orderbyExpression)
        {
            return ToPageList<T>(sugarQueryable, listfilter, pageInfo, ExpressionHelper.ConvertToString(orderbyExpression));
        }
    }
}
