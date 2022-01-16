using System.Collections.Generic;
using Microsoft.Extensions.Localization;
using SampleResourceManagementApp.Localization.LocalizationResources;

namespace SampleResourceManagementApp.Localization.VirtualFiles
{
    public interface ILocalizationResourceContributor
    {
        void Initialize(LocalizationResourceInitializationContext context);

        LocalizedString GetOrNull(string cultureName, string name);

        void Fill(string cultureName, Dictionary<string, LocalizedString> dictionary);
    }
}
