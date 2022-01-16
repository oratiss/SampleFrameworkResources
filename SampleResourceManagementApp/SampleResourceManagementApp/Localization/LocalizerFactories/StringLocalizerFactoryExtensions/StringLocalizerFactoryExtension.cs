using Microsoft.Extensions.Localization;

namespace SampleResourceManagementApp.Localization.LocalizerFactories.StringLocalizerFactoryExtensions
{
    public static class StringLocalizerFactoryExtension
    {
        public static IStringLocalizer CreateDefaultOrNull(this IStringLocalizerFactory localizerFactory)
        {
            return (localizerFactory as IStringLocalizerFactoryWithDefaultResourceSupport)
                ?.CreateDefaultOrNull();
        }
    }
}
