using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using thewall9.web.parent.Models;
using Microsoft.Extensions.Options;

namespace thewall9.web.parent.BLL
{
    public class SiteBLL : BaseBLL
    {
        public SiteBLL(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        public SiteFullBinding Get(int SiteID,string Url, string Lang, int CurrencyID)
        {
            return DownloadObject<SiteFullBinding>("api/site?SiteID=" + SiteID + "&Url=" + Url + "&Lang=" + Lang + "&CurrencyID=" + CurrencyID);
        }
        public List<CultureRoutes> GetLang(int SiteID, string Url)
        {
            return DownloadObject<List<CultureRoutes>>("api/site?SiteID=" + SiteID + "&Url=" + Url);
        }
    }
}