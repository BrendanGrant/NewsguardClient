using System;
using System.Collections.Generic;
using System.Text;

namespace NewsguardClient
{
    public class Criterion
    {
        public string title { get; set; }
        public string body { get; set; }
        public int order { get; set; }
    }

    public class NewsguardResponse
    {
        public string id { get; set; }
        public string identifier { get; set; }
        public string rank { get; set; }
        public double? score { get; set; }
        public string topline { get; set; }
        public string country { get; set; }
        public string language { get; set; }
        public List<Criterion> criteria { get; set; }
        public string labelToken { get; set; }
        public string locale { get; set; }
    }
}
