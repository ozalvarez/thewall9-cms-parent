

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using thewall9.web.parent.BLL;
using thewall9.web.parent.Result;

namespace thewall9.web.parent.Controllers
{
    public class BlogController : BaseController
    {
        private readonly BlogBLL _BlogService;
        private readonly ContentBLL _ContentService;

        public BlogController(IOptions<AppSettings> appSettings, APP app) : base(appSettings, app)
        {
            _BlogService = new BlogBLL(appSettings, app);
            _ContentService = new ContentBLL(appSettings, app);
            
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!_app.Site.Site.Blog)
                filterContext.Result = new StatusCodeResult(404);
        }
        [Route("blog/{BlogCategoryFriendlyUrl?}")]
        public ActionResult Index(string BlogCategoryFriendlyUrl, int Page = 1)
        {
            ViewBag.Page = Page;
            ViewBag.BlogCategoryFriendlyUrl = BlogCategoryFriendlyUrl;

            ViewBag.BlogContent = _ContentService.Get(Request.Host.Value, "blog");

            ViewBag.Title = TheWall9Extensions.FindValue(ViewBag.BlogContent, "blog-title", true).ToString();
            if (!string.IsNullOrEmpty(BlogCategoryFriendlyUrl))
                ViewBag.Title += " | " + BlogCategoryFriendlyUrl;

            ViewBag.MetaDescription = TheWall9Extensions.FindValue(ViewBag.BlogContent, "blog-subtitle", true).ToString();

            var _Model = _BlogService.Get(Request.Host.Value
                , _app.CurrentLang, BlogCategoryFriendlyUrl, null, Page);

            return View(_Model);
        }
        [Route("blog/tag/{BlogTagName}")]
        public ActionResult Tag(string BlogTagName, int Page = 1)
        {
            ViewBag.Page = Page;
            ViewBag.BlogTagName = BlogTagName;

            ViewBag.BlogContent = _ContentService.Get(Request.Host.Value, "blog");

            ViewBag.Title = TheWall9Extensions.FindValue(ViewBag.BlogContent, "blog-title", true).ToString() + " | " + BlogTagName;
            ViewBag.MetaDescription = TheWall9Extensions.FindValue(ViewBag.BlogContent, "blog-subtitle", true).ToString() + " | " + BlogTagName;

            return View("Index", _BlogService.Get(Request.Host.Value
                , _app.CurrentLang, null, BlogTagName, Page));
        }
        [Route("post/{BlogPostID}/{FriendlyUrl}")]
        public ActionResult Detail(int? BlogPostID, string FriendlyUrl)
        {
            if (BlogPostID == null) 
                return new StatusCodeResult(404);

            var _Model = _BlogService.GetDetail(Request.Host.Value, (int)BlogPostID, FriendlyUrl);
            if (_Model == null)
                return new StatusCodeResult(404);

            ViewBag.BlogContent = _ContentService.Get(Request.Host.Value, "blog");

            ViewBag.Title = _Model.Title;
            ViewBag.MetaDescription = _Model.ContentPreview;

            return View(_Model);
        }
        [Route("rss/{Lang?}")]
        public ActionResult Feed(string Lang)
        {
            if (string.IsNullOrEmpty(Lang))
                Lang = _app.CurrentLang;
            var _BlogContent = _ContentService.Get(Request.Host.Value, Lang, "blog");

            var _Title = TheWall9Extensions.FindValue(_BlogContent, "blog-title", true).ToString();
            var _Description = TheWall9Extensions.FindValue(_BlogContent, "blog-subtitle", true).ToString();

            var _Feeds = _BlogService.Get(Request.Host.Value, Lang, null, null, 1, true);
            return new RssResult(_Feeds.Data, _Title, _Description);
        }
    }
}