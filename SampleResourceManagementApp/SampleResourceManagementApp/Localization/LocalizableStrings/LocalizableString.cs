using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Localization;
using SampleResourceManagementApp.Utilities.Assertions;

namespace SampleResourceManagementApp.Localization.LocalizableStrings
{
    public class LocalizableString : ILocalizableString
    {
        [CanBeNull]
        public Type ResourceType { get; }

        [NotNull]
        public string Name { get; }

        public LocalizableString(Type resourceType, [NotNull] string name)
        {
            Name = LocalizationAssertion.NotNullOrEmpty(name, nameof(name));
            ResourceType = resourceType;
        }

        public LocalizedString Localize(IStringLocalizerFactory stringLocalizerFactory)
        {
            return stringLocalizerFactory.Create(ResourceType)[Name];
        }

        public static LocalizableString Create<TResource>([NotNull] string name)
        {
            return new LocalizableString(typeof(TResource), name);
        }
    }
}