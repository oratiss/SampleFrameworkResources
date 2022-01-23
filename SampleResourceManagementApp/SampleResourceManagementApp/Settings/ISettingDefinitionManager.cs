using System.Collections.Generic;

namespace SampleResourceManagementApp.Settings
{
    public interface ISettingDefinitionManager
    {
        SettingDefinition Get(string name);

        IReadOnlyList<SettingDefinition> GetAll();

        SettingDefinition GetOrNull(string name);
    }
}