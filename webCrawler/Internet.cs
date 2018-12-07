using System;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
namespace webCrawler
{
    public class Internet
    {
        public Page[] pages { get; set; }

        public class Page
        {
            public string address { get; set; }
            public string[] links { get; set; }
        }

        public Internet CreateInternet(string json)
        {
            return JsonConvert.DeserializeObject<Internet>(json);
        }
               
        public Internet()
        {
        }
    }
}
