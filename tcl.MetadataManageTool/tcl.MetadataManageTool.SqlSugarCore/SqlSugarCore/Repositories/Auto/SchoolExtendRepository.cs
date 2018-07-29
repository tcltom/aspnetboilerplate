using tcl.MetadataManageTool.IRepositories;
using tcl.MetadataManageTool.Models;

namespace tcl.MetadataManageTool.SqlSugarCore.Repositories
{
    /// <summary>
    /// 学校数据仓储接口实现
    /// </summary>
    public partial class SchoolRepository
    {
        private ISchoolGetPageListRepository _GetPageListable;

        private ISchoolGetRepository _Getable;

        private ISchoolGetListRepository _GetListable;

        private ISchoolCountRepository _Countable;

        private ISchoolExistRepository _Existable;

        private ISchoolQueryRepository _Queryable;

        private ISchoolSaveRepository _Saveable;

        public ISchoolGetPageListRepository GetPageListable
        {
            get
            {
                if (_GetPageListable == null)
                {
                    _GetPageListable = base.CreateInterface<ISchoolGetPageListRepository>();
                }

                return _GetPageListable;
            }
        }

        public ISchoolGetRepository Getable
        {
            get
            {
                if (_Getable == null)
                {
                    _Getable = base.CreateInterface<ISchoolGetRepository>();
                }

                return _Getable;
            }
        }

        public ISchoolGetListRepository GetListable
        {
            get
            {
                if (_GetListable == null)
                {
                    _GetListable = base.CreateInterface<ISchoolGetListRepository>();
                }

                return _GetListable;
            }
        }

        public ISchoolCountRepository Countable
        {
            get
            {
                if (_Countable == null)
                {
                    _Countable = base.CreateInterface<ISchoolCountRepository>();
                }

                return _Countable;
            }
        }

        public ISchoolExistRepository Existable
        {
            get
            {
                if (_Existable == null)
                {
                    _Existable = base.CreateInterface<ISchoolExistRepository>();
                }

                return _Existable;
            }
        }


        public ISchoolQueryRepository Queryable
        {
            get
            {
                if (_Queryable == null)
                {
                    _Queryable = base.CreateInterface<ISchoolQueryRepository>();
                }

                return _Queryable;
            }
        }

        public ISchoolSaveRepository Saveable
        {
            get
            {
                if (_Saveable == null)
                {
                    _Saveable = base.CreateInterface<ISchoolSaveRepository>();
                }

                return _Saveable;
            }
        }
    }
}

