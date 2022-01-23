using SampleResourceManagementApp.Localization.LocalizableStrings;
using SampleResourceManagementApp.Localization.LocalizationResources;
using SampleResourceManagementApp.Localization.LocalizationSettings;

namespace SampleResourceManagementApp.Settings
{
    public interface ISettingDefinitionProvider
    {
        void Define(ISettingDefinitionContext context);

    }

    public class LocalizationSettingProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(LocalizationSettingNames.DefaultLanguage,
                    "en",
                    L("DisplayName:Abp.Localization.DefaultLanguage"),
                    L("Description:Abp.Localization.DefaultLanguage"),
                    isVisibleToClients: true)
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LocalizationResource>(name);
        }
    }

    public abstract class SettingDefinitionProvider: ISettingDefinitionProvider
    {
        public abstract void Define(ISettingDefinitionContext context);
    }
}