using SampleResourceManagementApp.Localization.LocalizableStrings;
using SampleResourceManagementApp.Localization.LocalizationResources;
using SampleResourceManagementApp.Localization.LocalizationSettings;

namespace SampleResourceManagementApp.Settings
{
    public class LocalizationSettingProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(LocalizationSettingNames.DefaultLanguage,
                    "en",
                    L("DisplayName:Localization.DefaultLanguage"),
                    L("Description:Localization.DefaultLanguage"),
                    isVisibleToClients: true)
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LocalizationResource>(name);
        }
    }
}