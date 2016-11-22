﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace thewall9.web.parent.BLL
{

    public class BaseBLL
    {
        private readonly AppSettings _appSettings;
        public BaseBLL(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        private HttpClient MyWebClient
        {
            get
            {
                return new HttpClient();
            }
        }
        protected T DownloadObject<T>(string URI)
        {
            using (var _c = MyWebClient)
            {
                return JsonConvert.DeserializeObject<T>(_c.GetStringAsync(_appSettings.API + URI).Result);
            }
        }
    }
}
