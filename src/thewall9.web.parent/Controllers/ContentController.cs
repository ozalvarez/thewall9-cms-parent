

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using thewall9.web.parent.BLL;

namespace thewall9.web.parent.Controllers
{
    [Route("content")]
    public class ContentController : BaseController
    {
        private readonly ContentBLL _ContentService;

        public ContentController(IOptions<AppSettings> appSettings, APP app) : base(appSettings, app)
        {
            _ContentService = new ContentBLL(appSettings, app);
        }

        public PartialViewResult Index(string Alias, string View, int Take = 0)
        {
            ViewBag.Take = Take;
            return PartialView(View, _ContentService.Get(Request.Host.Value, Alias));
        }
    }
}