
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using thewall9.web.parent.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace thewall9.web.parent.Filters
{
    public class FilterBase : IActionFilter
    {
        private readonly AppSettings _appSettings;
        private readonly APP _app;

        private readonly SiteBLL _SiteService;
        public FilterBase(IOptions<AppSettings> appSettings, APP app)
        {
            _appSettings = appSettings.Value;
            _app = app;

            _SiteService = new SiteBLL(appSettings);
        }

        private string GetCultureISOLanguageName(HttpRequest Request, string DefaultCulture)
        {
            string CultureName = null;
            // Attempt to read the culture cookie from Request
            var cultureCookie = Request.Cookies["_Culture"];
            if (cultureCookie != null)
                CultureName = cultureCookie;
            else
            {
                var _UserLanguages = Request.Headers["Accept-Language"];
                if (_UserLanguages != StringValues.Empty)
                    CultureName = _UserLanguages.ToString().Split(',')[0];
            }
            if (!string.IsNullOrEmpty(CultureName))
            {
                CultureInfo.CurrentCulture = new CultureInfo(CultureName);
                CultureInfo.CurrentUICulture = new CultureInfo(CultureName);
            }
            return CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var _Request = context.HttpContext.Request;

            if (!context.RouteData.Values.ContainsKey("NoFilterBase"))
            {
                _app.Referer = "oz";
                //SET REFFERAL
                if (!string.IsNullOrEmpty(_Request.Headers["Referer"].ToString()) && string.IsNullOrEmpty(_app.Referer))
                    _app.Referer = _Request.Headers["Referer"].ToString();

                //SET LANGS
                _app.Langs = _SiteService.GetLang(_appSettings.SiteID, _Request.Host.Value);
                if (_app.Langs != null && _app.Langs.Count != 0)
                {
                    _app.CurrentLang = _app.Langs[0].Name;
                    _app.CurrentFriendlyUrl = _app.Langs[0].FriendlyUrl;
                    var _CultureName = GetCultureISOLanguageName(_Request, _app.CurrentLang);
                    var _SavedLang = _app.Langs.Where(m => _CultureName.Contains(m.Name)).FirstOrDefault();
                    if (_SavedLang != null)
                    {
                        _app.CurrentLang = _SavedLang.Name;
                        _app.CurrentFriendlyUrl = _SavedLang.FriendlyUrl;
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var _Request = context.HttpContext.Request;
            if (!context.RouteData.Values.ContainsKey("NoFilterBase"))
            {
                _app.Site = _SiteService.Get(_appSettings.SiteID, _Request.Host.Value, _app.CurrentLang, _app.CurrentCurrencyID);
            }
        }
    }
}