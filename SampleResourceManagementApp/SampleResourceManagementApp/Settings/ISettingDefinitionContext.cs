using System.Collections.Generic;

namespace SampleResourceManagementApp.Settings
{
    public interface ISettingDefinitionContext
    {
        SettingDefinition GetOrNull(string name);

        IReadOnlyList<SettingDefinition> GetAll();

        void Add(params SettingDefinition[] definitions);
    }
}