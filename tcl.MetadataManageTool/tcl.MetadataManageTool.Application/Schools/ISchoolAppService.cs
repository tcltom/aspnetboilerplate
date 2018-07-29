using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tcl.MetadataManageTool.Schools.Dto;

namespace tcl.MetadataManageTool.Schools
{

    public interface ISchoolAppService: IApplicationService
    {
        GetSchoolsOutput GetSchools(GetSchoolsInput data);
    }
}
