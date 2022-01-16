using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using SampleResourceManagementApp.Utilities.Assertions;
using SampleResourceManagementApp.Utilities.DisposeActions;
using SampleResourceManagementApp.Utilities.StringExtensions;

namespace SampleResourceManagementApp.Localization.CultureHelpers
{
    public class CultureHelper
    {
        public static IDisposable Use([NotNull] string culture, string uiCulture = null)
        {
            LocalizationAssertion.NotNull(culture, nameof(culture));

            return Use(
                new CultureInfo(culture),
                uiCulture == null
                    ? null
                    : new CultureInfo(uiCulture)
            );
        }

        public static IDisposable Use([NotNull] CultureInfo culture, CultureInfo uiCulture = null)
        {
            LocalizationAssertion.NotNull(culture, nameof(culture));

            var currentCulture = CultureInfo.CurrentCulture;
            var currentUiCulture = CultureInfo.CurrentUICulture;

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = uiCulture ?? culture;

            return new DisposeAction(() =>
            {
                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;
            });
        }

        public static bool IsRtl => CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;

        public static bool IsValidCultureCode(string cultureCode)
        {
            if (string.IsNullOrWhiteSpace(cultureCode))
            {
                return false;
            }

            try
            {
                CultureInfo.GetCultureInfo(cultureCode);
                return true;
            }
            catch (CultureNotFoundException)
            {
                return false;
            }
        }

        public static string GetBaseCultureName(string cultureName)
        {
            return cultureName.Contains("-")
                ? cultureName.Left(cultureName.IndexOf("-", StringComparison.Ordinal))
                : cultureName;
        }
    }
}
