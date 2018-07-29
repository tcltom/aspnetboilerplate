using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using SqlSugar;

namespace tcl.MetadataManageTool.Models
{
    [SugarTable("business.School")]
    public class School : ISoftDelete, IMustHaveTenant
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long SchoolId { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public int TenantId { get; set; }
    }
}
