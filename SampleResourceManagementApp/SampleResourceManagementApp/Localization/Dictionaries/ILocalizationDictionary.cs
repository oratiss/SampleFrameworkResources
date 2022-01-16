using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace SampleResourceManagementApp.Localization.Dictionaries
{
    public interface ILocalizationDictionary
    {
        string CultureName { get; }
        LocalizedString GetOrNull(string name);
        void Fill(Dictionary<string, LocalizedString> dictionary);
    }
}
