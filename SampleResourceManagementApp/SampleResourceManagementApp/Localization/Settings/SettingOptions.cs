using SampleResourceManagementApp.Localization.Collections;

namespace SampleResourceManagementApp.Localization.Settings
{
    public class SettingOptions
    {
        public ITypeLsit<ISettingDefinitionProvider> DefinitionProviders { get; set; }
        public ITypeList<ISettingValueProvider> ValueProviders { get; }

        public SettingOptions()
        {
            DefinitionProviders = new TypeList<ISettingDefinitionProvider>();
            ValueProviders = TypeList<ISettingValueProvider>();
        }
    }
}
