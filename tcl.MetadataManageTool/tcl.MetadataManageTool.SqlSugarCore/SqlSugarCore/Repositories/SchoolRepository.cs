using SqlSugar;
using tcl.MetadataManageTool.IRepositories;
using tcl.MetadataManageTool.Models;
using tcl.RepositoryExtend;

namespace tcl.MetadataManageTool.SqlSugarCore.Repositories
{
    /// <summary>
    /// 学校数据仓储接口实现
    /// </summary>
    public partial class SchoolRepository : MetadataManageToolRepositoryBase<School, SchoolOut, SchoolSave, SchoolQuery, long>, ISchoolRepository
    {
        private SqlSugarClient _db;

        public SchoolRepository(SqlSugarClient db) : base(db)
        {
            this._db = db;
        }

        public PageList<SchoolOut> test(SchoolQuery data)
        {
            return new PageList<SchoolOut>();
        }
    }
}

