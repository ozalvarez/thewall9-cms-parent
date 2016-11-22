

using Microsoft.Extensions.Options;
using thewall9.web.parent.Models;

namespace thewall9.web.parent.BLL
{
    public class ProductBLL : BaseBLL
    {
        public ProductBLL(IOptions<AppSettings> appSettings, APP app) : base(appSettings, app)
        {
        }

        public ProductsWeb Get(string Url
            , string ProductCategoryFriendlyUrl
            , int Page)
        {
            return DownloadObject<ProductsWeb>("api/product?SiteID=" +_appSettings.SiteID
                + "&Url=" + Url
                + "&Lang=" + _app.CurrentLang
                + "&CurrencyID=" + _app.CurrentCurrencyID
                + "&ProductCategoryFriendlyUrl=" + ProductCategoryFriendlyUrl
                + "&Page=" + Page);
        }
        public ProductWeb GetDetail(string Url
            , int ProductID
            , string FriendlyUrl)
        {
            return DownloadObject<ProductWeb>("api/product?SiteID=" + _appSettings.SiteID
                + "&Url=" + Url
                + "&ProductID=" + ProductID
                + "&FriendlyUrl=" + FriendlyUrl
                + "&CurrencyID=" + _app.CurrentCurrencyID);
        }
    }
}
