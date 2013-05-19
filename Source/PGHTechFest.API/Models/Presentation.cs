using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGHTechFest.API.Models
{
    public class Presentation
    {
        public string id { get; set; }
        public string time { get; set; }
        public string title { get; set; }
        public string track { get; set; }
        public string description { get; set; }
        public string presenter_id { get; set; }
        public string presenters_name { get; set; }
        public string presenters_bio { get; set; }
        public string presenters_twitter { get; set; }
        public string presenters_blog { get; set; }
        public string time_sort { get; set; }
        public string room { get; set; }
    }
}
