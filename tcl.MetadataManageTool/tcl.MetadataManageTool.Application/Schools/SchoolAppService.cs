using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tcl.MetadataManageTool.IRepositories;
using tcl.MetadataManageTool.Models;
using tcl.MetadataManageTool.Schools.Dto;

namespace tcl.MetadataManageTool.Schools
{
    public class SchoolAppService : MetadataManageToolAppServiceBase, ISchoolAppService
    {
        private readonly ISchoolRepository _repository;
        public SchoolAppService(ISchoolRepository repository)
        {
            this._repository = repository;
        }

        [UnitOfWork]
        public GetSchoolsOutput GetSchools(GetSchoolsInput data)
        {
            data.SchoolId = 1;
            data.Name = "123";
            this._repository.SoftDelete(4);
            var pdata = ObjectMapper.Map<SchoolQuery>(data);
            pdata.TenantId = 1;//从session中或其他地方获取
            var ret11 = this._repository.Count();
            var dddd=this._repository.Get(1);
            var dddd222 = this._repository.GetAllList();
            var dddd444= this._repository.FirstOrDefault(3);
            this._repository.Delete(new School() { SchoolId = 1 });
            var yyy=this._repository.Insert(new School() { SchoolId = 1, Name = "123", TenantId = 1, IsDeleted = false });
            var ttt=this._repository.Update(new School() { SchoolId = 1, Name = "123456", TenantId = 1, IsDeleted = false });
            this._repository.SoftDelete(1);
            var ret = this._repository.GetPageListable.BySchoolId(pdata.SetAppendMustFilter(false).SetFilters(null));
            var ret4444 = this._repository.GetPageListable.BySchoolIdAndName(pdata.SetAppendMustFilter(false).SetFilters(null));
            var ret2 = this._repository.GetListable.ByID(pdata.SetAppendMustFilter(false).SetFilters(null));
            var uyt=this._repository.Queryable.ByIdForName(new SchoolQuery());
            var uyt22 = this._repository.Queryable.ByIdForAge(new SchoolQuery());
            var uyt33 = this._repository.Queryable.ByDataByNote(new SchoolQuery());
            this._repository.Saveable.AddData(new SchoolSave());
            var yyyttt=this._repository.test(new SchoolQuery());
            return ObjectMapper.Map<GetSchoolsOutput>(ret);
        }
    }
}
