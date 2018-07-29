using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using tcl.MetadataManageTool.Roles.Dto;

namespace tcl.MetadataManageTool.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
