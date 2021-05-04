using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class CovidService
    {
        public List<RefCases> Get()
        {
            var res = new RestService();

            List<ClassCases> rows = res.getAllCasesPerMonthAsync();
            return SetCasesQntPerMonth(rows);
        }

        public List<RefCases> SetCasesQntPerMonth(List<ClassCases> data)
        {
            List<RefCases> listCases = new List<RefCases>();


            for (int i = 0; i < data.Count; i++)
            {
                int month = data[i].Date.Month;
                int total = GetDiffPerMonth(data[i != 0 ? i - 1 : 0].Cases, data[i].Cases);

                listCases.Add(new RefCases { mes = month, total = total });
            }
            return listCases;
        }

        public int GetDiffPerMonth(int prev, int next)
        {
            return next - prev;
        }

        public class RefCases
        {
            public int mes { get; set; }
            public int total { get; set; }

        }

    }
}
