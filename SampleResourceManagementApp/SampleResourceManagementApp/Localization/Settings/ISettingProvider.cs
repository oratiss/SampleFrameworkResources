using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace SampleResourceManagementApp.Localization.Settings
{
    public interface ISettingProvider
    {
        Task<string> GetOrNullAsync([NotNull] string name);

        Task<List<SettingValue>> GetAllAsync([NotNull] string[] names);

        Task<List<SettingValue>> GetAllAsync();
    }
}
