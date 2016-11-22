using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thewall9.web.parent.Controllers
{
    public class BaseController : Controller
    {
        protected readonly AppSettings _appSettings;
        protected readonly APP _app;
        public BaseController(IOptions<AppSettings> appSettings, APP app)
        {
            _appSettings = appSettings.Value;
            _app = app;
        }
    }
}
