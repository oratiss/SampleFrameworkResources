using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace SampleResourceManagementApp.Localization.RequestLocalizations
{
    public class RequestLocalizationMiddleware : IMiddleware
    {
        public const string HttpContextItemName = "__AbpSetCultureCookie";

        private readonly IRequestLocalizationOptionsProvider _requestLocalizationOptionsProvider;
        private readonly ILoggerFactory _loggerFactory;

        public RequestLocalizationMiddleware(
            IRequestLocalizationOptionsProvider requestLocalizationOptionsProvider,
            ILoggerFactory loggerFactory)
        {
            _requestLocalizationOptionsProvider = requestLocalizationOptionsProvider;
            _loggerFactory = loggerFactory;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var middleware = new Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware(
                next,
                new OptionsWrapper<RequestLocalizationOptions>(await _requestLocalizationOptionsProvider.GetLocalizationOptionsAsync()),
                _loggerFactory
            );

            context.Response.OnStarting(() =>
            {
                if (context.Items[HttpContextItemName] != null) return Task.CompletedTask;
                var requestCultureFeature = context.Features.Get<IRequestCultureFeature>();
                if (requestCultureFeature?.Provider is QueryStringRequestCultureProvider)
                {
                    RequestCultureCookieHelper.SetCultureCookie(
                        context,
                        requestCultureFeature.RequestCulture
                    );
                }

                return Task.CompletedTask;
            });

            await middleware.Invoke(context);
        }
    }
}
