using System.Threading.Tasks;
using Abp.Application.Services;
using tcl.MetadataManageTool.Authorization.Accounts.Dto;

namespace tcl.MetadataManageTool.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
