using System;
using System.Diagnostics.CodeAnalysis;
using SampleResourceManagementApp.Utilities.Assertions;

namespace SampleResourceManagementApp.Localization.LanguageInfos
{
    [Serializable]
    public class LanguageInfo : ILanguageInfo
    {
        [NotNull]
        public virtual string CultureName { get; protected set; }
        [NotNull]
        public virtual string UiCultureName { get; protected set; }
        [NotNull]
        public virtual string DisplayName { get; protected set; }
        [NotNull]
        public virtual string FlagIcon { get; protected set; }

        protected LanguageInfo()
        {
            
        }

        public LanguageInfo(string cultureName, string uiCultureName = null, string displayName = null, string flagIcon = null)
        {
            ChangeCultureInternal(cultureName, uiCultureName, displayName);
            FlagIcon = flagIcon;
        }

        private void ChangeCultureInternal(string cultureName, string uiCultureName, string displayName)
        {
            CultureName = LocalizationAssertion.NotNullOrWhiteSpace(cultureName, nameof(cultureName));

            UiCultureName = string.IsNullOrWhiteSpace(uiCultureName)
                ? uiCultureName
                : cultureName;

            DisplayName = string.IsNullOrWhiteSpace(displayName)
                ? displayName
                : cultureName;
        }

    }

}
