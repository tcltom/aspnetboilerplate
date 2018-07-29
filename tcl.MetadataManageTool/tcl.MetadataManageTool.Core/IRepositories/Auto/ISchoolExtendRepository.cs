using tcl.RepositoryExtend.Repository;

namespace tcl.MetadataManageTool.IRepositories
{
    /// <summary>
    /// 学校数据仓储接口
    /// </summary>
    public partial interface ISchoolRepository
    {
        ISchoolGetPageListRepository GetPageListable { get; }

        ISchoolGetRepository Getable { get; }

        ISchoolGetListRepository GetListable { get; }

        ISchoolCountRepository Countable { get; }

        ISchoolExistRepository Existable { get; }

        ISchoolQueryRepository Queryable { get; }

        ISchoolSaveRepository Saveable { get; }
    }

    public partial interface ISchoolGetPageListRepository: IGetPageListRepository
    {

    }

    public partial interface ISchoolGetRepository : IGetRepository
    {

    }

    public partial interface ISchoolGetListRepository: IGetListRepository
    {

    }

    public partial interface ISchoolCountRepository: ICountRepository
    {

    }

    public partial interface ISchoolExistRepository: IExistRepository
    {

    }

    public partial interface ISchoolQueryRepository: IQueryRepository
    {
    }


    public partial interface ISchoolSaveRepository: ISaveRepository
    {

    }
}
