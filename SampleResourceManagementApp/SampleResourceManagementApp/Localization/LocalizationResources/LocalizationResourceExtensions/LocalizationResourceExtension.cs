using System;
using System.Diagnostics.CodeAnalysis;
using SampleResourceManagementApp.Localization.Collections.CollectionExtensions;
using SampleResourceManagementApp.Localization.VirtualFiles;
using SampleResourceManagementApp.Utilities.Assertions;
using SampleResourceManagementApp.Utilities.StringExtensions;

namespace SampleResourceManagementApp.Localization.LocalizationResources.LocalizationResourceExtensions
{
    public static class LocalizationResourceExtension
    {
        public static LocalizationResource AddBaseTypes([NotNull] this LocalizationResource localizationResource, [NotNull] params Type[] types)
        {
            LocalizationAssertion.NotNull(localizationResource, nameof(localizationResource));
            LocalizationAssertion.NotNull(types, nameof(types));

            foreach (var type in types)
                localizationResource.BaseResourceTypes.AddIfNotContains(type);

            return localizationResource;
        }

        public static LocalizationResource AddVirtualJson([NotNull] this LocalizationResource localizationResource, [NotNull] string virtualPath)
        {
            LocalizationAssertion.NotNull(localizationResource, nameof(localizationResource));
            LocalizationAssertion.NotNull(virtualPath, nameof(virtualPath));

            localizationResource.Contributors.Add(new JsonVirtualFileLocalizationResourceContributor(
                virtualPath.EnsureStartsWith('/')
            ));

            return localizationResource;
        }
    }
}
