using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcl.RepositoryExtend;

namespace tcl.SqlSugarExtend
{
    public static class SqlSugarHelper
    {
        /// <summary>
        /// SqlParamInfo转换为SugarParameter
        /// </summary>
        /// <param name="data">要转换的SqlParamInfo参数</param>
        /// <param name="isAppendParam">是否添加追加的参数，默认true</param>
        /// <returns></returns>
        public static KeyValuePair<string, List<SugarParameter>> ConvertToSugarParameter(this SqlParamInfo data, bool isAppendParam = true)
        {
            if (data == null)
            {
                return new KeyValuePair<string, List<SugarParameter>>();
            }

            KeyValuePair<string, List<SugarParameter>> sugarSqlParameter = new KeyValuePair<string, List<SugarParameter>>(data.Sql, new List<SugarParameter>());
            if (data.Param != null)
            {
                if (data.Param is List<SugarParameter>)//注意此代码逻辑在其他逻辑前面
                {
                    var temParam = (List<SugarParameter>)data.Param;
                    sugarSqlParameter.Value.AddRange(temParam);
                }
                else if (data.Param is Dictionary<string, object>)
                {
                    var temParam = (Dictionary<string, object>)data.Param;
                    foreach (var item in temParam)
                    {
                        sugarSqlParameter.Value.Add(new SugarParameter(item.Key, item.Value));
                    }
                }
                else if (data.Param.GetType().IsClass)//注意此代码逻辑放在最后
                {
                    var listProperty = data.Param.GetType().GetProperties();
                    foreach (var propertyInfo in listProperty)
                    {
                        sugarSqlParameter.Value.Add(new SugarParameter(propertyInfo.Name, propertyInfo.GetValue(data.Param)));
                    }
                }
                else
                {
                    throw new Exception("暂不支持其他类型的参数对象转换为SugarParameter对象");
                }
            }

            if (isAppendParam && data.AppendParam != null)
            {
                ////添加追加的参数
                foreach (var item in data.AppendParam)
                {
                    sugarSqlParameter.Value.Add(new SugarParameter(item.Key, item.Value));
                }
            }

            return sugarSqlParameter;
        }
    }
}
