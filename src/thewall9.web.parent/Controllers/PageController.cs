using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using thewall9.web.parent.BLL;

namespace thewall9.web.parent.Controllers
{
    public class PageController : BaseController
    {
        private readonly PageBLL _PageService;
        private readonly ProductBLL _ProductService;
        private const int PAGE_SIZE = 10;

        public PageController(IOptions<AppSettings> appSettings, APP app) : base(appSettings, app)
        {
            _PageService = new PageBLL(appSettings, app);
            _ProductService = new ProductBLL(appSettings, app);
        }

        public IActionResult Index(string FriendlyUrl)
        {
            if (string.IsNullOrEmpty(FriendlyUrl))
            {
                if (!string.IsNullOrEmpty(_app.CurrentFriendlyUrl))
                    return Redirect("/" + _app.CurrentFriendlyUrl);
            }
            var _Model = _PageService.Get(FriendlyUrl, _appSettings.SiteID, Request.Host.Value);
            if (_Model == null)
                return new StatusCodeResult(404);
            else
            {
                if (!string.IsNullOrEmpty(_Model.Page.RedirectUrl))
                    return Redirect(_Model.Page.RedirectUrl);

                ViewBag.Title = _Model.Page.TitlePage;
                ViewBag.MetaDescription = _Model.Page.MetaDescription;
                ViewBag.Active = "page-" + FriendlyUrl;

                ViewBag.OGraph = _Model.Page.OGraph;

                _app.CurrentLang = _Model.Page.CultureName;
                return View(_Model.Page.ViewRender, _Model);
            }
        }
    }
}
