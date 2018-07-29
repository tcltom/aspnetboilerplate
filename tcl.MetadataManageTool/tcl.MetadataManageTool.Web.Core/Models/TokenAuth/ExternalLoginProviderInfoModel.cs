using Abp.AutoMapper;
using tcl.MetadataManageTool.Authentication.External;

namespace tcl.MetadataManageTool.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
