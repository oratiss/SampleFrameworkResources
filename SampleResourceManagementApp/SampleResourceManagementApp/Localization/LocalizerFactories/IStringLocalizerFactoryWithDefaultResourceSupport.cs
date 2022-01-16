#nullable enable
using Microsoft.Extensions.Localization;

namespace SampleResourceManagementApp.Localization.LocalizerFactories
{
    public interface IStringLocalizerFactoryWithDefaultResourceSupport
    {
        IStringLocalizer? CreateDefaultOrNull();
    }
}
