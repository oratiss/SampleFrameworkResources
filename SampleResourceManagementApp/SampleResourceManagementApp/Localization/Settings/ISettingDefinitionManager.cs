﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SampleResourceManagementApp.Localization.Settings
{
    public interface ISettingDefinitionManager
    {
        [NotNull]
        SettingDefinition Get([NotNull] string name);

        IReadOnlyList<SettingDefinition> GetAll();

        SettingDefinition GetOrNull(string name);
    }
}