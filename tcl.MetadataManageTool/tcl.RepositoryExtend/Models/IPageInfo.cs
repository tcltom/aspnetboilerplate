using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    public interface IPageInfo
    {
        int PageSize { get; set; }

        int PageIndex{ get; set; }

        int StartRowIndex { get;}

        int EndRowIndex { get; }

        int SkipNum { get; }
    }
}
