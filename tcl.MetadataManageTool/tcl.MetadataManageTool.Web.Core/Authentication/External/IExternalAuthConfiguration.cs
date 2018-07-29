using System.Collections.Generic;

namespace tcl.MetadataManageTool.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
