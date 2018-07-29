using System.Collections.Generic;
using tcl.MetadataManageTool.Models;
using tcl.RepositoryExtend;

namespace tcl.MetadataManageTool.IRepositories
{
    #region //分组仓储接口,不用分组可以直接删除

    public partial interface ISchoolGetPageListRepository
    {
        /// <summary>
        /// 根据学校id获取学校信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        PageList<SchoolOut> BySchoolId(SchoolQuery data);

        PageList<SchoolOut> BySchoolIdAndName(SchoolQuery data);
    }

    public partial interface ISchoolGetRepository
    {
        /// <summary>
        /// 根据学校id获取学校信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        SchoolOut BySchoolId(SchoolQuery data);
    }

    public partial interface ISchoolGetListRepository
    {
        /// <summary>
        /// 获取学校列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        List<SchoolOut> ByID(SchoolQuery data);
    }

    public partial interface ISchoolCountRepository
    {
        /// <summary>
        /// 获取学校总数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int ByID(SchoolQuery data);
    }

    public partial interface ISchoolExistRepository
    {
        /// <summary>
        /// 是否存在学校
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool ByID(School data);
    }

    public partial interface ISchoolQueryRepository
    {
        /// <summary>
        /// 获取学校名称
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string ByIdForName(SchoolQuery data);

        /// <summary>
        /// 获取学校年龄
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        decimal ByIdForAge(SchoolQuery data);

        /// <summary>
        /// 获取学校描述
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string ByDataByNote(SchoolQuery data);

    }

    public partial interface ISchoolSaveRepository
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void AddData(SchoolSave data);
    }

    #endregion
}
