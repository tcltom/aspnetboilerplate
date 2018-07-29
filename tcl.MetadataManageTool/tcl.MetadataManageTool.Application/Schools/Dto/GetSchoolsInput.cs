using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using tcl.MetadataManageTool.Models;

namespace tcl.MetadataManageTool.Schools.Dto
{
    [AutoMapTo(typeof(SchoolQuery))]
    public class GetSchoolsInput
    {
        public long SchoolId { get; set; }

        public string Name { get; set; }
    }
}
