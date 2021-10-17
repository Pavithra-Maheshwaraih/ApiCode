using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiCode.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpGet("{ipadress}")]
        public string Get(string ipadress)
        {
            Ipinfo ipInfo = new Ipinfo();
            var cityLocation = "";
            try
            {
                string info = new WebClient().DownloadString("https://ipinfo.io/" + ipadress);
                if (info != null)
                {
                    ipInfo = JsonConvert.DeserializeObject<Ipinfo>(info);
                    if (ipInfo.City != null)
                    {
                        cityLocation = ipInfo.City;
                    }
                }
            }
            catch (Exception)
            {
                cityLocation = null;
            }

            return cityLocation;
        }

    }
}
