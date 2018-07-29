using Abp.Application.Services;
using Abp.Application.Services.Dto;
using tcl.MetadataManageTool.MultiTenancy.Dto;

namespace tcl.MetadataManageTool.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
