

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace thewall9.web.parent.ActionFilter
{
    public class Redirect301ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var _Request = filterContext.HttpContext.Request;
            string _Url = _Request.Host.Value;
            if (_Url.Contains("://www."))
            {
                if (!_Request.IsHttps)
                    _Url = _Url.Replace("http://www.", "http://");
                else
                    _Url = _Url.Replace("https://www.", "http://");
                filterContext.Result = new RedirectResult(_Url, true);
                filterContext.Result.ExecuteResultAsync(filterContext);
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
