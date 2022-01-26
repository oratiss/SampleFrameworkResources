using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace SampleResourceManagementApp.Localization.RequestLocalizations
{
    public static class RequestCultureCookieHelper
    {
        public static void SetCultureCookie(
            HttpContext httpContext,
            RequestCulture requestCulture)
        {
            httpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(requestCulture),
                new CookieOptions
                {
                    IsEssential = true,
                    Expires = DateTime.Now.AddYears(2)
                }
            );
        }
    }
}
