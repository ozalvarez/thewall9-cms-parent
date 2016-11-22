
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using thewall9.web.parent.Models;

namespace thewall9.web.parent
{
    public class APP
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private IDictionary<object, object> _items => _httpContextAccessor.HttpContext.Items;
        private IRequestCookieCollection _cookiesRequest => _httpContextAccessor.HttpContext.Request.Cookies;
        private IResponseCookies _cookiesResponse => _httpContextAccessor.HttpContext.Response.Cookies;
        public APP(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Referer
        {
            get
            {
                return _session.GetString("Referer");
            }
            set
            {
                _session.SetString("Referer", value);
            }
        }
        public SiteFullBinding Site
        {
            get
            {
                return _session.GetObjectFromJson<SiteFullBinding>("Site");
            }
            set
            {
                _session.SetObjectAsJson("Site", value);
            }
        }

        public string CurrentLang
        {
            get
            {
                return _items["CurrentLang"] as string;
            }
            set
            {
                _items["CurrentLang"] = value;
            }
        }
        public string CurrentFriendlyUrl
        {
            get
            {
                return _items["CurrentFriendlyUrl"] as string;
            }
            set
            {
                _items["CurrentFriendlyUrl"] = value;
            }
        }
        public List<CultureRoutes> Langs
        {
            get
            {
                return _session.GetObjectFromJson<List<CultureRoutes>>("Langs");
            }
            set
            {
                _session.SetObjectAsJson("Langs", value);
            }
        }
        public int CurrentCurrencyID
        {
            get
            {
                var _Value = _session.GetInt32("CurrentCurrencyID");
                if (_Value != null)
                    return (int)_Value;
                else
                {
                    var _Cookie = Convert.ToInt32(_cookiesRequest["CurrentCurrencyID"]);
                    _session.SetInt32("CurrentCurrencyID", _Cookie);
                    return _Cookie;
                }
            }
            set
            {
                _session.SetInt32("_CurrentCurrencyID",value);
                _cookiesResponse.Append("_CurrentCurrencyID", value.ToString());
            }
        }
    }
}