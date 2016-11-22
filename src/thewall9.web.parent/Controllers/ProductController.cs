

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using thewall9.web.parent.BLL;

namespace thewall9.web.parent.Controllers
{

    public class ProductController : BaseController
    {
        private readonly ProductBLL _ProductService;
        private readonly CategoryBLL _CategoryService;
        private readonly ContentBLL _ContentService;

        public ProductController(IOptions<AppSettings> appSettings, APP app) : base(appSettings, app)
        {
            _ProductService = new ProductBLL(appSettings, app);
            _CategoryService=new CategoryBLL(appSettings, app);
            _ContentService = new ContentBLL(appSettings, app);
        }

        [Route("product/{ProductID}/{FriendlyUrl}")]
        public ActionResult Detail(int ProductID, string FriendlyUrl)
        {
            var _Model = _ProductService.GetDetail(Request.Host.Value, ProductID, FriendlyUrl);
            if (_Model == null)
                return new StatusCodeResult(404);

            ViewBag.Content = _ContentService.Get(Request.Host.Value, "product");

            ViewBag.Title = _Model.ProductName;
            ViewBag.MetaDescription = _Model.Description;

            return View(_Model);
        }
        [Route("products/{View}/{ProductCategoryFriendlyUrl}/{Page?}")]
        public PartialViewResult List(string View, string ProductCategoryFriendlyUrl = null, int Page = 1)
        {
            var _P = _ProductService.Get(Request.Host.Value
                , ProductCategoryFriendlyUrl
                , Page);
            return PartialView(View, _P);
        }
        //CATEGORIES
        [Route("category/{CategoryID}/{FriendlyUrl}/{Page?}")]
        public ActionResult Category(int CategoryID, string FriendlyUrl, int Page = 1)
        {
            var _Products = _ProductService.Get(Request.Host.Value, FriendlyUrl, Page);
            var _Category = _CategoryService.GetByID(CategoryID, FriendlyUrl);
            if (_Products == null || _Category == null)
                return new StatusCodeResult(404);

            ViewBag.Content = _ContentService.Get(Request.Host.Value, "category");
            ViewBag.Products = _Products;

            ViewBag.Title = _Category.CategoryName;
            //TO-DO ADD DESCRIPTION TO CATEGORY
           // ViewBag.MetaDescription = _Model.Description;

            return View(_Category);
        }
    }
}