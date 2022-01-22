using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using SampleResourceManagementApp.Localization.Dictionaries.DictionariesExtensions;

namespace SampleResourceManagementApp.Localization.Settings
{
    public class SettingDefinitionContext: ISettingDefinitionContext

    {
        protected Dictionary<string, SettingDefinition> Settings { get; }

        public SettingDefinitionContext(Dictionary<string, SettingDefinition> settings)
        {
            Settings = settings;
        }

        public virtual SettingDefinition GetOrNull(string name)
        {
            return Settings.GetOrDefault(name);
        }

        public virtual IReadOnlyList<SettingDefinition> GetAll()
        {
            return Settings.Values.ToImmutableList();
        }

        public virtual void Add(params SettingDefinition[] definitions)
        {
            if (!definitions.Any())
                return;

            foreach (var definition in definitions)
                Settings[definition.Name] = definition;
        }
    }
}
