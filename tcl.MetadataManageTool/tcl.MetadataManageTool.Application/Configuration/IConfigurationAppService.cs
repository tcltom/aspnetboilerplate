using System.Threading.Tasks;
using tcl.MetadataManageTool.Configuration.Dto;

namespace tcl.MetadataManageTool.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
