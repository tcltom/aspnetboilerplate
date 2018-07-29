using Abp.Domain.Repositories;
using Abp.SqlSugarCore.Repositories;
using System.Collections.Generic;
using tcl.MetadataManageTool.Models;
using tcl.RepositoryExtend;

namespace tcl.MetadataManageTool.IRepositories
{
    /// <summary>
    /// 学校数据仓储接口
    /// </summary>
    public partial interface ISchoolRepository : IRepository<School, long>
    {
        PageList<SchoolOut> test(SchoolQuery data);
    }
}
