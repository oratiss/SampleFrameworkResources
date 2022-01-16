using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace SampleResourceManagementApp.Localization.StringLocalizers
{
    public interface IStringLocalizerSupportsInheritance
    {
        IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures, bool includeBaseLocalizers);
    }
}