using System.Collections.Generic;
using System.Web.Http;
using Core;

namespace Controllers
{
    public class CovidController : ApiController
    {
        [Route("api/covid/casos/mensais")]
        [HttpGet]
        public List<Core.CovidService.grpCases> Get()
        {
            var covidService = new CovidService();
            List<Core.CovidService.grpCases> response = covidService.Get();
            return response;
        }
    }

}
