using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    public class BaseRepositoryQuery<T> : RepositoryFilters<T>, IPageInfo, IMayHaveTenant where T : BaseRepositoryQuery<T>
    {
        /// <summary>
        /// 页容(默认20条)
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// 当前页号(默认第1页)
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 跳过数量
        /// </summary>
        public int SkipNum
        {
            get
            {
                var index = PageIndex >= 1 ? PageIndex - 1 : 0;
                return index * PageSize;
            }
        }

        /// <summary>
        /// 开始行号(编号从1开始)
        /// </summary>
        public int StartRowIndex
        {
            get
            {
                var index = PageIndex >= 1 ? PageIndex - 1 : 0;
                return index * PageSize + 1;//注意加1
            }
        }

        /// <summary>
        /// 结束行号
        /// </summary>
        public int EndRowIndex
        {
            get
            {
                return StartRowIndex + PageSize - 1;//注意减1
            }
        }

        /// <summary>
        /// 租户id
        /// </summary>
        public int? TenantId { get; set; }
    }
}
