using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SampleResourceManagementApp.Settings
{
    public class SettingValueProviderManager : ISettingValueProviderManager
    {
        public List<ISettingValueProvider> Providers => _lazyProviders.Value;
        protected SettingOptions Options { get; }
        private readonly Lazy<List<ISettingValueProvider>> _lazyProviders;

        public SettingValueProviderManager(
            IServiceProvider serviceProvider,
            IOptions<SettingOptions> options)
        {

            Options = options.Value;

            _lazyProviders = new Lazy<List<ISettingValueProvider>>(
                () => Options
                    .ValueProviders
                    .Select(type => serviceProvider.GetRequiredService(type) as ISettingValueProvider)
                    .ToList(),
                true
            );
        }
    }
}