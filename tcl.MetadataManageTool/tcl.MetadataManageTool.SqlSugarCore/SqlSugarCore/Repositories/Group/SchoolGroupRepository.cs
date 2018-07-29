using System.Collections.Generic;
using tcl.MetadataManageTool.IRepositories;
using tcl.MetadataManageTool.Models;
using tcl.RepositoryExtend;
using tcl.SqlSugarExtend;
using tcl.SqlSugarExtend.Models;
using SqlSugar;

namespace tcl.MetadataManageTool.SqlSugarCore.Repositories
{
    /// <summary>
    /// 学校数据仓储接口实现(对方法进行分组实现,若未对方法进行分组，可以删除)
    /// </summary>
    public partial class SchoolRepository
    {

        protected override PageList<SchoolOut> GetPageList(string methodName, SchoolQuery data)
        {
            if (methodName == nameof(ISchoolGetPageListRepository.BySchoolId))
            {
                var ttt = _db.SqlQueryable<SchoolOut>("select * from business.School")
                    .WhereIF(true, p => p.SchoolId == 1)
                    .WhereIF(data.SchoolId > 0, p => p.SchoolId == 1)
                    .WhereIF(data.SchoolId > 0, p => p.SchoolId == 1)
                    .ToPageList(data, p => new OrderByAsc(p.Name));
                var ddd = _db.Ado.GetPageList<SchoolOut>("select * from business.School ", data, p => new OrderByDesc(p.Name), p => new OrderByAsc(p.Name, p.TenantId), p => new OrderByDesc(p.SchoolId));//执行sql
                var query = _db.Queryable<School, School>((st, sc) => new object[] {
        JoinType.Left,st.SchoolId==sc.SchoolId}).Where((st, sc) => st.SchoolId == data.SchoolId && st.Name == data.Name)
       .Select((st, sc) => new SchoolOut { SchoolId = SqlFunc.GetSelfAndAutoFill(st.SchoolId), UserName = sc.Name });
                return query.ToPageList(data, p => new OrderByAsc(p.Name));//执行表达式
            }
            else if (methodName == nameof(ISchoolGetPageListRepository.BySchoolIdAndName))
            {
                return null;
            }

            return base.GetPageList(methodName, data);
        }

        protected override List<SchoolOut> GetList(string methodName, SchoolQuery data)
        {
            if (methodName == nameof(ISchoolGetListRepository.ByID))
            {
                var yyy = _db.Queryable<School>().Select(p => new SchoolOut { SchoolId = SqlFunc.GetSelfAndAutoFill(p.SchoolId) });
                var yy = yyy.ToPageList(data, p => new OrderByAsc(p.Name));//执行表达式
                var ddd = _db.Ado.GetPageList<SchoolOut>("select * from business.School ", data, p => new OrderByAsc(p.Name), p => new OrderByAsc(p.SchoolId));//执行sql
                return ddd.Rows;
            }

            return base.GetList(methodName, data);
        }

        protected override SchoolOut Get(string methodName, SchoolQuery data)
        {
            if (methodName == nameof(ISchoolGetRepository.BySchoolId))
            {
                return null;
            }

            return base.Get(methodName, data);
        }

        protected override bool Exist(string methodName, SchoolQuery data)
        {
            if (methodName == nameof(ISchoolExistRepository.ByID))
            {
                return true;
            }

            return base.Exist(methodName, data);
        }

        protected override object Query(string methodName, SchoolQuery data)
        {

            if (methodName == nameof(ISchoolQueryRepository.ByIdForName))//获取学校名称
            {
                return "test学校";
            }
            else if (methodName == nameof(ISchoolQueryRepository.ByIdForAge))//获取学校年龄
            {
                return 22.5m;
            }
            else if (methodName == nameof(ISchoolQueryRepository.ByDataByNote))//获取学校描述
            {
                return "这是学校的描述情况";
            }

            return base.Query(methodName, data);
        }

        protected override int Count(string methodName, SchoolQuery data)
        {
            if (methodName == nameof(ISchoolCountRepository.ByID))
            {
                return 2;
            }

            return base.Count(methodName, data);
        }

        protected override void Save(string methodName, SchoolSave data)
        {
            if (methodName == nameof(ISchoolSaveRepository.AddData))
            {
                return;
            }

            base.Save(methodName, data);
        }
    }
}
