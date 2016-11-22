

using Microsoft.Extensions.Options;
using thewall9.web.parent.Models;

namespace thewall9.web.parent.BLL
{
    public class BlogBLL : BaseBLL
    {
        public BlogBLL(IOptions<AppSettings> appSettings, APP app) : base(appSettings, app)
        {
        }

        public BlogListWeb Get(string Url
            , string Lang
            , string BlogCategoryFriendlyUrl
            , string BlogTagName
            , int Page
            , bool IncludeContent = false)
        {
            return DownloadObject<BlogListWeb>("api/blog?SiteID=" + _appSettings.SiteID
                + "&Url=" + Url
                + "&Lang=" + Lang
                + "&BlogCategoryFriendlyUrl=" + BlogCategoryFriendlyUrl
                + "&BlogTagName=" + BlogTagName
                + "&Page=" + Page
                + "&IncludeContent=" + IncludeContent);
        }
        public BlogPostWeb GetDetail(string Url, int BlogPostID, string FriendlyUrl)
        {
            return DownloadObject<BlogPostWeb>("api/blog?SiteID=" + _appSettings.SiteID
                + "&Url=" + Url
                + "&BlogPostID=" + BlogPostID
                + "&FriendlyUrl=" + FriendlyUrl);
        }
    }
}
