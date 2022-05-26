using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinDataLocal.Helpers;
using XamarinDataLocal.Models;

namespace XamarinDataLocal.Repositories
{
    public class RepositorySeries
    {
        public List<Serie> GetSeries()
        {
            string data = HelperFiles.ReadFile("series.json");
            List<Serie> series =
                JsonConvert.DeserializeObject<List<Serie>>(data);
            return series;
        }
    }
}
