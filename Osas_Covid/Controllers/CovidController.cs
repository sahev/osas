using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;

namespace Osas_Covid.Controllers
{
    public class CovidController : ApiController
    {
        [Route("api")]
        [HttpGet]
        public List<Core.CovidService.RefCases> Get()
        {
            var covidService = new CovidService();
            List<Core.CovidService.RefCases> response = covidService.Get();
            return response;
        }
    }

}
