using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SampleResourceManagementApp.Localization.LanguageInfos;
using SampleResourceManagementApp.Localization.LocalizationOptionConfigurations;
using SampleResourceManagementApp.Localization.LocalizationResources.LocalizationResourceExtensions;
using SampleResourceManagementApp.Localization.RequestLocalizations;
using SampleResourceManagementApp.Localization.ResourceFiles;
using System;
using SampleResourceManagementApp.EncryptionServices;
using SampleResourceManagementApp.Localization.LocalizableStrings;
using SampleResourceManagementApp.Localization.NameValues;
using SampleResourceManagementApp.Settings;

namespace SampleResourceManagementApp.StartupExtensions
{
    public static class StartupExtension
    {
        public static void ConfigureLocalizationServices(this IServiceCollection services)
        {


            services.AddTransient<ILocalizableString, LocalizableString>();
            services.AddTransient<ILocalizableString, FixedLocalizableString>();
            services.AddTransient<ISettingDefinition, SettingDefinition>();
            services.AddTransient<ISettingEncryptionService, SettingEncryptionService>();
            services.AddTransient<ISettingDefinitionProvider, SettingDefinitionProvider>();
            services.AddTransient<ISettingDefinitionManager, SettingDefinitionManager>();
            services.AddScoped<NameValue<string>>();
            services.AddScoped<NameValue>();
            services.AddScoped<SettingValue>();

            services.AddTransient<ISettingValueProvider, SettingValueProvider>();
            services.AddTransient<ISettingValueProvider, DefaultValueSettingValueProvider>();
            services.AddTransient<ISettingProvider, SettingProvider>();

            services.AddSingleton<SettingValueProviderManager,SettingValueProviderManager>();
            services.AddTransient<ISettingDefinitionContext, SettingDefinitionContext>();
            services.AddTransient<IStringEncryptionService, StringEncryptionService>();



           



            Configure<WorkLocalizationOption>(services, options =>
            {
                options.Languages.Add(new LanguageInfo("fa", "fa-Ir", "فارسی"));
                options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
                options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
                options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
                options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
                options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
                options.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
                options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
                options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
                options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
                options.Languages.Add(new LanguageInfo("es", "es", "Español"));

                options.DefaultResourceType = typeof(SampleResourceManagementAppResource);

                options.Resources
                    .Add<SampleResourceManagementAppResource>("en")
                    .AddBaseTypes(typeof(SampleResourceManagementAppValidationResource), typeof(SampleResourceManagementAppResource))
                    .AddVirtualJson("/Localization/ResourceFiles/SampleResourceManagementApp");

            });
        }

        public static void Configure<TOptions>(IServiceCollection services, Action<TOptions> configureOptions)
            where TOptions : class
        {
            services.Configure(configureOptions);
        }

        public static IApplicationBuilder UseFrameworkRequestLocalization(this IApplicationBuilder app,
            Action<RequestLocalizationOptions> optionsAction = null)
        {
            app.ApplicationServices
                .GetRequiredService<IRequestLocalizationOptionsProvider>()
                .InitLocalizationOptions(optionsAction);

            return app.UseMiddleware<RequestLocalizationMiddleware>();
        }
    }
}
