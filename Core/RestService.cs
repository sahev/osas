using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Core
{
    public class RestService
    {
        public List<ClassCases> getAllCasesPerMonth()
        {
            var url = "https://api.covid19api.com/country/brazil/status/confirmed";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader rd = new StreamReader(stream))
            {
                var res = rd.ReadToEnd();
                return JsonConvert.DeserializeObject<List<ClassCases>>(res).ToList();
            }
        }
    }

    public class ClassCases
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public int Cases { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

    }
}
