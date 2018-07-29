using System;
using System.Collections.Generic;
using System.Text;
using tcl.RepositoryExtend;

namespace tcl.MetadataManageTool.Models
{
    public class SchoolQuery : BaseRepositoryQuery<SchoolQuery>
    {
        public long SchoolId { get; set; }

        public string Name { get; set; }
    }
}

