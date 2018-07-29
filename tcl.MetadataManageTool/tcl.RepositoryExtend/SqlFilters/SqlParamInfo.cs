using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    /// <summary>
    /// Sql和参数信息类
    /// </summary>
    public class SqlParamInfo
    {
        /// <summary>
        /// sql语句
        /// </summary>
        public string Sql { get; set; }

        /// <summary>
        /// sql参数
        /// </summary>
        public object Param { get; set; }

        /// <summary>
        /// 追加的参数
        /// </summary>
        public Dictionary<string, object> AppendParam { get; set; }

        public SqlParamInfo(string sql, object param = null, Dictionary<string, object> appendParam = null)
        {
            this.Sql = sql;
            this.Param = param;
            this.AppendParam = appendParam;
        }

        /// <summary>
        /// 要追加的参数
        /// </summary>
        /// <param name="parameterName">参数名</param>
        /// <param name="parameterValue">参数值</param>
        public SqlParamInfo AddParam(string parameterName, object parameterValue)
        {
            if (this.AppendParam == null)
            {
                this.AppendParam = new Dictionary<string, object>();
            }

            this.AppendParam.Add(parameterName, parameterValue);

            return this;
        }

        /// <summary>
        /// 要追加的参数
        /// </summary>
        /// <param name="data">参数对象</param>
        public SqlParamInfo AddParam(object data)
        {
            if (data != null)
            {
                if (this.AppendParam == null)
                {
                    this.AppendParam = new Dictionary<string, object>();
                }

                if (data is Dictionary<string, object>)
                {
                    var temParam = (Dictionary<string, object>)data;
                    foreach (var item in temParam)
                    {
                        this.AppendParam.Add(item.Key, item.Value);
                    }
                }
                else if (data.GetType().IsClass)//注意此代码逻辑放在最后
                {
                    var listProperty = this.Param.GetType().GetProperties();
                    foreach (var propertyInfo in listProperty)
                    {
                        this.AppendParam.Add(propertyInfo.Name, propertyInfo.GetValue(this.Param));
                    }
                }
                else
                {
                    throw new Exception("只支持追加类对象和字典对象的参数");
                }
            }

            return this;
        }

        /// <summary>
        /// 复制参数,避免内存数据共享
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public SqlParamInfo Copy()
        {
            object copyParam = null;
            Dictionary<string, object> copyAppendParam = null;
            if (this.Param != null)
            {
                ////注意复制需要用新的列表，避免内存数据共享
                if (this.Param.GetType().IsGenericType)
                {
                    var temParams = (System.Collections.IEnumerable)this.Param;
                    var newlist = Activator.CreateInstance(this.Param.GetType()) as System.Collections.IList;
                    foreach (var item in temParams)
                    {
                        newlist.Add(item);
                    }

                    copyParam = newlist;
                }
                else if (this.Param is Dictionary<string, object>)
                {
                    copyParam = ((Dictionary<string, object>)this.Param).ToDictionary(p => p.Key, p => p.Value);
                }
                else if (this.Param.GetType().IsClass)
                {
                    //暂未实现，目前没影响,待研究
                }
            }

            if (this.AppendParam != null)
            {
                copyAppendParam = ((Dictionary<string, object>)this.AppendParam).ToDictionary(p => p.Key, p => p.Value);
            }

            return new SqlParamInfo(this.Sql, copyParam, copyAppendParam);//其他暂时不变
        }
    }
}
