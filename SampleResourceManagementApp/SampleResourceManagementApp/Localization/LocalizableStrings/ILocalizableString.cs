using Microsoft.Extensions.Localization;

namespace SampleResourceManagementApp.Localization.LocalizableStrings
{
    public interface ILocalizableString
    {
        LocalizedString Localize(IStringLocalizerFactory stringLocalizerFactory);
    }
}