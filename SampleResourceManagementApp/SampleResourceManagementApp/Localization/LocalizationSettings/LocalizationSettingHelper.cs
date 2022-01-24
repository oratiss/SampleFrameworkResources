using JetBrains.Annotations;
using SampleResourceManagementApp.Utilities.Assertions;

namespace SampleResourceManagementApp.Localization.LocalizationSettings
{
    public class LocalizationSettingHelper
    {
        /// <summary>
        /// Gets a setting value like "en-US;en" and returns as splitted values like ("en-US", "en").
        /// </summary>
        /// <param name="settingValue"></param>
        /// <returns></returns>
        public static (string cultureName, string uiCultureName) ParseLanguageSetting([NotNull] string settingValue)
        {
            LocalizationAssertion.NotNull(settingValue, nameof(settingValue));

            if (!settingValue.Contains(";"))
            {
                return (settingValue, settingValue);
            }

            var splitted = settingValue.Split(';');
            return (splitted[0], splitted[1]);
        }
    }
}
