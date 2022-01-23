using System.Collections.Generic;

namespace SampleResourceManagementApp.Settings
{
    public interface ISettingValueProviderManager
    {
        List<ISettingValueProvider> Providers { get; }
    }
}