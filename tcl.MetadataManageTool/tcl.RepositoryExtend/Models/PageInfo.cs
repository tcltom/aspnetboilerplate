using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    public class PageInfo : IPageInfo
    {
        /// <summary>
        /// 页容
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageIndex { get; set; }

        public PageInfo()
        {

        }

        public PageInfo(int pageSize, int pageIndex)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
        }

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
                return index * PageSize+1;//注意加1
            }
        }

        /// <summary>
        /// 结束行号
        /// </summary>
        public int EndRowIndex
        {
            get
            {
                return StartRowIndex + PageSize-1;//注意减1
            }
        }
    }
}
