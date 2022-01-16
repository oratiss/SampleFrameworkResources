using System;
using System.Collections.Concurrent;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SampleResourceManagementApp.Localization.Dictionaries.DictionariesExtensions;
using SampleResourceManagementApp.Localization.LocalizationOptionConfigurations;
using SampleResourceManagementApp.Localization.LocalizationResources;
using SampleResourceManagementApp.Localization.StringLocalizers;
using SampleResourceManagementApp.Localization.VirtualFiles;

namespace SampleResourceManagementApp.Localization.LocalizerFactories
{
    public class StringLocalizerFactory : IStringLocalizerFactory, IStringLocalizerFactoryWithDefaultResourceSupport
    {
        protected internal WorkLocalizationOption WorkLocalizationOption { get; }
        protected ResourceManagerStringLocalizerFactory InnerFactory { get; }
        protected IServiceProvider ServiceProvider { get; }
        protected ConcurrentDictionary<Type, StringLocalizerCacheItem> LocalizerCache { get; }

        //TODO: It's better to use decorator pattern for IStringLocalizerFactory instead of getting ResourceManagerStringLocalizerFactory as a dependency.
        public StringLocalizerFactory(
            ResourceManagerStringLocalizerFactory innerFactory,
            IOptions<WorkLocalizationOption> workLocalizationOption,
            IServiceProvider serviceProvider)
        {
            InnerFactory = innerFactory;
            ServiceProvider = serviceProvider;
            WorkLocalizationOption = workLocalizationOption.Value;

            LocalizerCache = new ConcurrentDictionary<Type, StringLocalizerCacheItem>();
        }

        public virtual IStringLocalizer Create(Type resourceType)
        {
            var resource = WorkLocalizationOption.Resources.GetOrDefault(resourceType);
            if (resource == null)
            {
                return InnerFactory.Create(resourceType);
            }

            if (LocalizerCache.TryGetValue(resourceType, out var cacheItem))
            {
                return cacheItem.Localizer;
            }

            lock (LocalizerCache)
            {
                return LocalizerCache.GetOrAdd(
                    resourceType,
                    _ => CreateStringLocalizerCacheItem(resource)
                ).Localizer;
            }
        }

        private StringLocalizerCacheItem CreateStringLocalizerCacheItem(LocalizationResource resource)
        {
            foreach (var globalContributor in WorkLocalizationOption.GlobalContributors)
            {
                resource.Contributors.Add((ILocalizationResourceContributor)Activator.CreateInstance(globalContributor));
            }

            var context = new LocalizationResourceInitializationContext(resource, ServiceProvider);

            foreach (var contributor in resource.Contributors)
            {
                contributor.Initialize(context);
            }

            return new StringLocalizerCacheItem(
                new DictionaryBasedStringLocalizer(
                    resource,
                    resource.BaseResourceTypes.Select(Create).ToList()
                )
            );
        }

        public virtual IStringLocalizer Create(string baseName, string location)
        {
            //TODO: Investigate when this is called?

            return InnerFactory.Create(baseName, location);
        }

        internal static void Replace(IServiceCollection services)
        {
            services.Replace(ServiceDescriptor.Singleton<IStringLocalizerFactory, StringLocalizerFactory>());
            services.AddSingleton<ResourceManagerStringLocalizerFactory>();
        }

        protected class StringLocalizerCacheItem
        {
            public DictionaryBasedStringLocalizer Localizer { get; }

            public StringLocalizerCacheItem(DictionaryBasedStringLocalizer localizer)
            {
                Localizer = localizer;
            }
        }

        public IStringLocalizer CreateDefaultOrNull()
        {
            if (WorkLocalizationOption.DefaultResourceType == null)
            {
                return null;
            }

            return Create(WorkLocalizationOption.DefaultResourceType);
        }
    }
}
