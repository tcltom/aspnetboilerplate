using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using tcl.MetadataManageTool.Roles.Dto;
using tcl.MetadataManageTool.Users.Dto;

namespace tcl.MetadataManageTool.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
