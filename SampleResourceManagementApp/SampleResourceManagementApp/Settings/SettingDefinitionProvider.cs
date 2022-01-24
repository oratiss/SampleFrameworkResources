namespace SampleResourceManagementApp.Settings
{
    public abstract class SettingDefinitionProvider: ISettingDefinitionProvider
    {
        public abstract void Define(ISettingDefinitionContext context);
    }
}