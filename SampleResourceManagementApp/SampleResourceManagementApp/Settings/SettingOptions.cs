using SampleResourceManagementApp.Localization.Collections;

namespace SampleResourceManagementApp.Settings
{
    public class SettingOptions
    {
        public ITypeList<ISettingDefinitionProvider> DefinitionProviders { get; set; }
        public ITypeList<ISettingValueProvider> ValueProviders { get; }

        public SettingOptions()
        {
            DefinitionProviders = new TypeList<ISettingDefinitionProvider>();
            ValueProviders = new TypeList<ISettingValueProvider>();
        }
    }
}
