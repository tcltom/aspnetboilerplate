using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    public class PageList<T>
    {
        public PageList()
        {

        }

        public PageList(List<T> rows, int count)
        {
            this.Rows = rows;
            this.Count = count;
        }

        public List<T> Rows { get; set; }

        public int Count { get; set; }
    }
}
