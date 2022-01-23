﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SampleResourceManagementApp.SettingManagement;

namespace SampleResourceManagementApp.Settings
{
    public abstract class SettingValueProvider : ISettingValueProvider
    {
        public abstract string Name { get; }

        protected ISettingStore SettingStore { get; }

        protected SettingValueProvider(ISettingStore settingStore)
        {
            SettingStore = settingStore;
        }

        public abstract Task<string> GetOrNullAsync(SettingDefinition setting);

        public abstract Task<List<SettingValue>> GetAllAsync(SettingDefinition[] settings);
    }
}