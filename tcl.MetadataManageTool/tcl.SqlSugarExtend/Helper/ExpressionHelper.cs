using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using tcl.SqlSugarExtend.Models;

namespace tcl.SqlSugarExtend.Helper
{
    public class ExpressionHelper
    {
        public static string ConvertToString<T>(params Expression<Func<T, IOrderBy>>[] orderbyExpressions)
        {
            string orderstring = "";
            if (orderbyExpressions != null && orderbyExpressions.Length > 0)
            {
                foreach (var orderbyExpression in orderbyExpressions)
                {
                    orderstring = orderstring + "," + ConvertToString(orderbyExpression);
                }
            }

            return orderstring.Trim().Trim(',');
        }

        private static string ConvertToString<T>(Expression<Func<T, IOrderBy>> orderbyExpression)
        {
            string orderstring = "";
            string ordersign = " asc";
            if (orderbyExpression.Body is NewExpression) //new表达式
            {
                var newEx = (orderbyExpression.Body as NewExpression);
                if (newEx.Type == typeof(OrderByDesc))
                {
                    ordersign = " desc";
                }

                var arguments = newEx.Arguments;
                if (arguments != null && arguments.Count > 0)
                {
                    foreach (var argument in arguments)
                    {
                        if (argument is NewArrayExpression)//new多成员表达式
                        {
                            var newarrayEx = argument as NewArrayExpression;
                            foreach (var proEx in newarrayEx.Expressions)
                            {
                                if (proEx is MemberExpression)//成员表达式
                                {
                                    var menmberEx = proEx as MemberExpression;
                                    orderstring = orderstring + "," + menmberEx.Member.Name + ordersign;
                                }
                                else if (proEx is UnaryExpression)//带一元参数方法表达式
                                {
                                    var unaryEx = proEx as UnaryExpression;
                                    if (unaryEx.Operand is MemberExpression)
                                    {
                                        var menmberEx = unaryEx.Operand as MemberExpression;
                                        orderstring = orderstring + "," + menmberEx.Member.Name + ordersign;
                                    }
                                }
                            }
                        }
                        else if (argument is MemberExpression)
                        {
                            var menmberEx = argument as MemberExpression;
                            orderstring = orderstring + "," + menmberEx.Member.Name + ordersign;
                        }
                        else if (argument is UnaryExpression)
                        {
                            var unaryEx = argument as UnaryExpression;
                            if (unaryEx.Operand is MemberExpression)
                            {
                                var menmberEx = unaryEx.Operand as MemberExpression;
                                orderstring = orderstring + "," + menmberEx.Member.Name + ordersign;
                            }
                        }
                    }
                }
            }

            return orderstring.Trim().Trim(',');
        }
    }
}
