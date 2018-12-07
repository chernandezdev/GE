using System;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
namespace webCrawler
{
    public class InternetResults
    {
        public List<string> InternetValid { get; set; }
        public List<string> InternetDuplicate { get; set; }
        public List<string> InternetInvalid { get; set; }

        public InternetResults()
        {
        }
    }
}
