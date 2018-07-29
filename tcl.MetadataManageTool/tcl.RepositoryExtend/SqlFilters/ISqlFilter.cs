using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcl.RepositoryExtend
{
    public interface ISqlFilter
    {

        SqlParamInfo Run(SqlParamInfo info);
    }
}
