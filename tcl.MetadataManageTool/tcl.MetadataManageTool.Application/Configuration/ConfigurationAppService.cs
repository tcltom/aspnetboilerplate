using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using tcl.MetadataManageTool.Configuration.Dto;

namespace tcl.MetadataManageTool.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MetadataManageToolAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
