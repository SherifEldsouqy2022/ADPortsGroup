using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ADPortsGroup.Localization
{
    public static class ADPortsGroupLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ADPortsGroupConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ADPortsGroupLocalizationConfigurer).GetAssembly(),
                        "ADPortsGroup.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
