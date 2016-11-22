

using Microsoft.Extensions.Options;
using thewall9.web.parent.Models;

namespace thewall9.web.parent.BLL
{
    public class ContentBLL : BaseBLL
    {
        public ContentBLL(IOptions<AppSettings> appSettings, APP app) : base(appSettings, app)
        {
        }

        public ContentBindingList Get(string Url, string Lang, string ContentAlias)
        {
            return DownloadObject<ContentBindingList>("api/content?SiteID=" + _appSettings.SiteID
                + "&Url=" + Url
                + "&Lang=" + Lang
                + "&AliasList=" + ContentAlias);
        }
        public ContentBindingList Get(string Url, string ContentAlias)
        {
            return Get(Url, _app.CurrentLang, ContentAlias);
        }
    }
}
