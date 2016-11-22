using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thewall9.web.parent.Models
{
    public class SiteBinding
    {
        public int SiteID { get; set; }
        public string DefaultLang { get; set; }
        public string SiteName { get; set; }
        public string GAID { get; set; }
        public bool Enabled { get; set; }
        public DateTime DateCreated { get; set; }
        public bool ECommerce { get; set; }
        public bool Blog { get; set; }
    }
    public class SiteFullBinding
    {
        public SiteBinding Site { get; set; }
        public List<PageCultureBinding> Menu { get; set; }
        public List<PageCultureBinding> EcommercePages { get; set; }
        public List<PageCultureBinding> OtherPages { get; set; }
        public ContentBindingList ContentLayout { get; set; }
        public List<CurrencyBinding> Currencies { get; set; }
        public List<CategoryWeb> Categories { get; set; }
    }
    public class PageCultureBase
    {
        public string Name { get; set; }
        public string TitlePage { get; set; }
        public string MetaDescription { get; set; }
        public string FriendlyUrl { get; set; }
        public string ViewRender { get; set; }
        public string RedirectUrl { get; set; }
        public bool Published { get; set; }
    }
    public class PageCultureBinding : PageCultureBase
    {
        public int SiteID { get; set; }
        public int PageID { get; set; }
        public int CultureID { get; set; }
        public string CultureName { get; set; }
        public string PageAlias { get; set; }
        public List<PageCultureBinding> Items { get; set; }
        public OGraphBinding OGraph { get; set; }
    }
    public class OGraphBase
    {
        public int OGraphID { get; set; }
        public string OGraphTitle { get; set; }
        public string OGraphDescription { get; set; }
    }
    public class OGraphBinding : OGraphBase
    {
        public FileRead FileRead { get; set; }
    }
    public class FileRead : MediaBase
    {
        public string FileContent { get; set; }
        public string FileName { get; set; }
        public bool Deleting { get; set; }
        public bool Adding { get; set; }
    }
    public class MediaBase
    {
        public int MediaID { get; set; }
        public string MediaUrl { get; set; }
        public int SiteID { get; set; }
    }
    public class ContentBindingList : ContentBinding
    {
        public ICollection<ContentBindingList> Items { get; set; }
        public IEnumerable<ContentCultureBinding> ContentCultures { get; set; }
    }
    public class ContentCultureBase
    {
        public string ContentPropertyValue { get; set; }
        public string Hint { get; set; }

    }
    public class ContentCultureBinding : ContentCultureBase
    {
        public int ContentPropertyID { get; set; }
        public int CultureID { get; set; }
        public string ContentPropertyBinary { get; set; }
        public string CultureName { get; set; }
    }
    public class ContentBinding : ContentBase
    {

    }
    public class ContentBase
    {
        public int ContentPropertyID { get; set; }
        public int ContentPropertyParentID { get; set; }
        public int SiteID { get; set; }
        public ContentPropertyType ContentPropertyType { get; set; }
        public string ContentPropertyAlias { get; set; }
        public int Priority { get; set; }
        public bool Lock { get; set; }
        public bool ShowInContent { get; set; }
        public bool Enabled { get; set; }
        /// <summary>
        /// In Menu when editing Properties in Customer Portal
        /// </summary>
        public bool InMenu { get; set; }
    }
    public enum ContentPropertyType
    {
        IMG = 1,
        TXT = 2,
        LIST = 3,
        HTML = 4
    }
    public class CurrencyBinding : CurrencyBase
    {
    }
    public class CurrencyBase
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public bool Default { get; set; }
        public int SiteID { get; set; }
        public string MoneySymbol { get; set; }
        public double ShippingPrice { get; set; }
    }
    public class CategoryWeb : CategoryCultureBase
    {
        public int CategoryID { get; set; }
        public List<CategoryWeb> CategoryItems { get; set; }
        public string IconUrl { get; set; }
        public int CultureID { get; set; }
    }
    public class CategoryCultureBase
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string FriendlyUrl { get; set; }
    }
    public class CultureRoutes : CultureBase
    {
        public string FriendlyUrl { get; set; }
    }
    public class CultureBase
    {
        public int CultureID { get; set; }
        public int SiteID { get; set; }
        public string Name { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string GPlus { get; set; }
        public string Tumblr { get; set; }
        public string Instagram { get; set; }
        public string Rss { get; set; }
        public string YoutubeChannel { get; set; }
    }
    public class BlogListWeb
    {
        public int Pages { get; set; }
        public List<BlogPostWeb> Data { get; set; }
        public List<BlogCategoryCultureBase> Categories { get; set; }
        public List<BlogTagBase> Tags { get; set; }
    }
    public class BlogPostWeb : BlogPostCultureBase
    {
        public string FeatureImageUrl { get; set; }
        public int SiteID { get; set; }
        public List<BlogCategoryCultureBase> AllCategories { get; set; }
        public List<BlogTagBase> AllTags { get; set; }
        public List<BlogTagBase> Tags { get; set; }
        public List<BlogCategoryCultureBase> Categories { get; set; }
    }
    public class BlogCategoryCultureBase
    {
        public int BlogCategoryID { get; set; }
        public int CultureID { get; set; }
        public string BlogCategoryName { get; set; }
        public string FriendlyUrl { get; set; }
    }
    public class BlogTagBase
    {
        public int BlogTagID { get; set; }
        public string BlogTagName { get; set; }
    }
    public class BlogPostCultureBase
    {
        public int BlogPostID { get; set; }
        public int CultureID { get; set; }
        public bool Published { get; set; }
        public string Content { get; set; }
        public string ContentPreview { get; set; }
        public string FriendlyUrl { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class PageWeb
    {
        public PageCultureBinding Page { get; set; }
        public ContentBindingList Content { get; set; }
    }
    public class SiteMapModel
    {
        public bool Ecommerce { get; set; }

        public List<PageCultureBinding> Pages { get; set; }
        public List<ProductWeb> Products { get; set; }
        public List<CategoryWeb> Categories { get; set; }

        public bool Blog { get; set; }
        public List<BlogPostWeb> Posts { get; set; }
        public List<BlogCategoryCultureBase> BlogCategories { get; set; }
        public List<BlogTagBase> BlogTags { get; set; }
    }
    public class ProductsWeb
    {
        public List<ProductWeb> Products { get; set; }
        public List<CategoryWeb> Categories { get; set; }
        public int NumberPages { get; set; }
        public int CultureID { get; set; }
        public string CultureName { get; set; }
        public CategoryWeb Category { get; set; }
    }
    public class ProductWeb : ProductCultureBase
    {
        public int ProductID { get; set; }
        public double Price { get; set; }
        public double PriceOld { get; set; }
        public string CultureName { get; set; }
        public List<ProductGalleryBinding> Galleries { get; set; }
        public bool New { get; set; }
        public bool Featured { get; set; }
        public bool Sale { get; set; }
    }
    public class ProductCultureBase
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }
        public string IconPath { get; set; }
        public string FriendlyUrl { get; set; }
    }
    public class ProductGalleryBinding : ProductGalleryBase
    {

    }
    public class ProductGalleryBase
    {
        public int ProductGalleryID { get; set; }
        public int ProductID { get; set; }
        public string PhotoPath { get; set; }
    }
}
