using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleResourceManagementApp.Localization.RequestLocalizations
{
    public class FrameworkRequestLocalizationOptions
    {
        public List<Func<IServiceProvider, RequestLocalizationOptions, Task>> RequestLocalizationOptionConfigurators { get; }

        public FrameworkRequestLocalizationOptions()
        {
            RequestLocalizationOptionConfigurators = new List<Func<IServiceProvider, RequestLocalizationOptions, Task>>();
        }
    }
}
