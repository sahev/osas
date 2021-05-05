using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class CovidService
    {
        public List<grpCases> Get() 
        {
            var res = new RestService();
            List<ClassCases> rows = res.getAllCasesPerMonth();
            return SetCasesQntPerMonth(rows);
        }

        public List<grpCases> SetCasesQntPerMonth(List<ClassCases> data)
        {
            List<grpCases> listCases = new List<grpCases>();

            for (int i = 0; i < data.Count; i++)
            {
                var dt = data[i].Date.ToString("MM/yyyy");
                int total = GetDiffPerMonth(data[i != 0 ? i - 1 : 0].Cases, data[i].Cases);

                listCases.Add(new grpCases { mes = dt, total = total });
            }
            return grpCasesPerMonth(listCases);
        }

        public int GetDiffPerMonth(int prev, int next)
        {
            return next - prev;
        }

        public List<grpCases> grpCasesPerMonth(List<grpCases> data)
        {
            List<grpCases> grpCases = new List<grpCases>();
            var cases = data.GroupBy(r => r.mes)
                            .Select(g => new { data = g.Key, tot = g.Sum(x => x.total) });

            grpCases.Clear();

            foreach (var cas in cases)
            {
                grpCases.Add(new grpCases { mes = cas.data, total = cas.tot });
            }
            return grpCases;
        }

        public class grpCases
        {
            public string mes { get; set; }
            public int total { get; set; }
        }

    }
}
