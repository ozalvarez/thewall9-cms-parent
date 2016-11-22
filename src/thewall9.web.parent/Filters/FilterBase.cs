
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace thewall9.web.parent.Filters
{
    public class FilterBase : IActionFilter
    {
        private readonly AppSettings _appSettings;
        public FilterBase(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(">>>>>>>>>>", _appSettings.API);
            // do something before the action executes
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}