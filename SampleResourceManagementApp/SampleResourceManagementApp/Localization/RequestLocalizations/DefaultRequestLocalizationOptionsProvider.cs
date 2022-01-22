using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SampleResourceManagementApp.Localization.LocalizationProvider;
using SampleResourceManagementApp.Threading;

namespace SampleResourceManagementApp.Localization.RequestLocalizations
{
    public class DefaultRequestLocalizationOptionsProvider:IRequestLocalizationOptionsProvider
    {

        private readonly IServiceScopeFactory _serviceProviderFactory;
        private readonly SemaphoreSlim _syncSemaphore;
        private Action<RequestLocalizationOptions> _optionsAction;
        private RequestLocalizationOptions _requestLocalizationOptions;

        public DefaultRequestLocalizationOptionsProvider(IServiceScopeFactory serviceProviderFactory)
        {
            _serviceProviderFactory = serviceProviderFactory;
            _syncSemaphore = new SemaphoreSlim(1, 1);
        }
        public void InitLocalizationOptions(Action<RequestLocalizationOptions> optionsAction = null)
        {
            _optionsAction = optionsAction;
        }

        public async Task<RequestLocalizationOptions> GetLocalizationOptionsAsync()
        {
            if (_requestLocalizationOptions == null)
            {
                using (await _syncSemaphore.LockAsync())
                {
                    if (_requestLocalizationOptions == null)
                    {
                        using (var serviceScope = _serviceProviderFactory.CreateScope())
                        {
                            var languageProvider = serviceScope.ServiceProvider.GetRequiredService<ILanguageProvider>();
                            var settingProvider = serviceScope.ServiceProvider.GetRequiredService<ISettingProvider>();

                            var languages = await languageProvider.GetLanguagesAsync();
                            var defaultLanguage = await settingProvider.GetOrNullAsync(LocalizationSettingNames.DefaultLanguage);

                            var options = !languages.Any()
                                ? new RequestLocalizationOptions()
                                : new RequestLocalizationOptions
                                {
                                    DefaultRequestCulture = DefaultGetRequestCulture(defaultLanguage, languages),

                                    SupportedCultures = languages
                                        .Select(l => l.CultureName)
                                        .Distinct()
                                        .Select(c => new CultureInfo(c))
                                        .ToArray(),

                                    SupportedUICultures = languages
                                        .Select(l => l.UiCultureName)
                                        .Distinct()
                                        .Select(c => new CultureInfo(c))
                                        .ToArray()
                                };

                            foreach (var configurator in serviceScope.ServiceProvider
                                .GetRequiredService<IOptions<RequestLocalizationOptions>>()
                                .Value.RequestLocalizationOptionConfigurators)
                            {
                                await configurator(serviceScope.ServiceProvider, options);
                            }

                            _optionsAction?.Invoke(options);
                            _requestLocalizationOptions = options;
                        }
                    }
                }
            }

            return _requestLocalizationOptions;
        }
    }
}
