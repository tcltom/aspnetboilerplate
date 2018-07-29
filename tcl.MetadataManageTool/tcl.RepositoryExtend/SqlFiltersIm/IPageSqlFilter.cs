using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    public interface IPageSqlFilter : ISqlFilter
    {
        string OrderSql { get; set; }
    }
}
