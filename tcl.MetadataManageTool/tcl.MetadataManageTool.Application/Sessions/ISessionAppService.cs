using System.Threading.Tasks;
using Abp.Application.Services;
using tcl.MetadataManageTool.Sessions.Dto;

namespace tcl.MetadataManageTool.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
