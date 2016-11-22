
using Microsoft.Extensions.Options;
using thewall9.web.parent.Models;

namespace thewall9.web.parent.BLL
{
    public class PageBLL:BaseBLL
    {
        public PageBLL(IOptions<AppSettings> appSettings, APP app) : base(appSettings, app)
        {
        }

        public PageWeb Get(string FriendlyUrl, int SiteID, string Url)
        {
            return DownloadObject<PageWeb>("api/page?SiteID=" + SiteID + "&Url=" + Url + "&FriendlyUrl=" + FriendlyUrl);
        }
        public PageWeb GetByAlias(int SiteID, string Url, string Alias, string Lang)
        {
            return DownloadObject<PageWeb>("api/page?SiteID=" + SiteID + "&Url=" + Url + "&Alias=" + Alias + "&Lang=" + Lang);
        }
        public string GetPageFriendlyUrl(int SiteID, string Url, string FriendlyUrl, string TargetLang)
        {
            return DownloadObject<string>("api/page?SiteID=" + SiteID + "&Url=" + Url + "&FriendlyUrl=" + FriendlyUrl+"&TargetLang="+TargetLang);
        }
        public SiteMapModel GetSitemap(int SiteID, string Url)
        {
            return DownloadObject<SiteMapModel>("api/page/sitemap?SiteID=" + SiteID + "&Url=" + Url);
        }
    }
}
