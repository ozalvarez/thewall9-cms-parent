

using Microsoft.Extensions.Options;
using thewall9.web.parent.Models;

namespace thewall9.web.parent.BLL
{
    public class CategoryBLL : BaseBLL
    {
        public CategoryBLL(IOptions<AppSettings> appSettings, APP app) : base(appSettings, app)
        {
        }

        public CategoryWeb GetByID(int CategoryID
            , string FriendlyUrl)
        {
            return DownloadObject<CategoryWeb>("api/category?CategoryID=" + CategoryID
                + "&FriendlyUrl=" + FriendlyUrl);
        }
    }
}
