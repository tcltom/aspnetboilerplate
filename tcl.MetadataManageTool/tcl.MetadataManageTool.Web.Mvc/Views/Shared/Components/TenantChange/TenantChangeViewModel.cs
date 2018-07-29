using Abp.AutoMapper;
using tcl.MetadataManageTool.Sessions.Dto;

namespace tcl.MetadataManageTool.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
