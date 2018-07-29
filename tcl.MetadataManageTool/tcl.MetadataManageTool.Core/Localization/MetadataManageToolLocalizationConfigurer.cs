using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace tcl.MetadataManageTool.Localization
{
    public static class MetadataManageToolLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MetadataManageToolConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MetadataManageToolLocalizationConfigurer).GetAssembly(),
                        "tcl.MetadataManageTool.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
