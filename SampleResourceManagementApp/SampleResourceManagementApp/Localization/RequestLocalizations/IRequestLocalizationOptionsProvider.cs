using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace SampleResourceManagementApp.Localization.RequestLocalizations
{
    public interface IRequestLocalizationOptionsProvider
    {
        void InitLocalizationOptions(Action<RequestLocalizationOptions> optionsAction = null);

        Task<RequestLocalizationOptions> GetLocalizationOptionsAsync();
    }
}