using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using SampleResourceManagementApp.DependencyInjection;
using SampleResourceManagementApp.Localization.LocalizationOptionConfigurations;
using SampleResourceManagementApp.Localization.LocalizerFactories.StringLocalizerFactoryExtensions;


namespace SampleResourceManagementApp.Pages.BasePageModels
{
    public abstract class BasePageModel : PageModel
    {
        public ILazyServiceProvider LazyServiceProvider { get; set; }
        protected IStringLocalizerFactory StringLocalizerFactory => LazyServiceProvider.LazyGetRequiredService<IStringLocalizerFactory>();

        protected IStringLocalizer L
        {
            get
            {
                if (_localizer == null)
                {
                    _localizer = CreateLocalizer();
                }

                return _localizer;
            }
        }

        private IStringLocalizer _localizer;

        protected Type LocalizationResourceType { get; set; }


        protected virtual IStringLocalizer CreateLocalizer()
        {
            if (LocalizationResourceType != null)
            {
                return StringLocalizerFactory.Create(LocalizationResourceType);
            }

            var localizer = StringLocalizerFactory.CreateDefaultOrNull();
            if (localizer == null)
            {
                throw new Exception($"Set {nameof(LocalizationResourceType)} or define the default localization resource type (by configuring the {nameof(WorkLocalizationOption)}.{nameof(WorkLocalizationOption.DefaultResourceType)}) to be able to use the {nameof(L)} object!");
            }

            return localizer;
        }

 
    }
}
