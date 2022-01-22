using System.Collections.Generic;
using System.Threading.Tasks;
using SampleResourceManagementApp.Localization.LanguageInfos;

namespace SampleResourceManagementApp.Localization.LocalizationProvider
{
    public interface ILanguageProvider
    {
        Task<IReadOnlyList<LanguageInfo>> GetLanguagesAsync();
    }
}