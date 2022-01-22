using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SampleResourceManagementApp.Localization.LanguageInfos;
using SampleResourceManagementApp.Localization.LocalizationOptionConfigurations;

namespace SampleResourceManagementApp.Localization.LocalizationProvider
{
    public class DefaultLanguageProvider : ILanguageProvider
    {
        protected WorkLocalizationOption Options { get; }

        public DefaultLanguageProvider(IOptions<WorkLocalizationOption> options)
        {
            Options = options.Value;
        }

        public Task<IReadOnlyList<LanguageInfo>> GetLanguagesAsync()
        {
            return Task.FromResult((IReadOnlyList<LanguageInfo>)Options.Languages);
        }
    }
}
