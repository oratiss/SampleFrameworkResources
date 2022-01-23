using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace SampleResourceManagementApp.Settings
{
    public interface ISettingValueProvider
    {
        public string Name { get; }
        Task<string> GetOrNullAsync([NotNull] SettingDefinition setting);
        Task<List<SettingValue>> GetAllAsync([NotNull] SettingDefinition[] settings);
    }
}