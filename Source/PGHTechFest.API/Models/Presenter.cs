using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGHTechFest.API.Models
{
    public class Presenter
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string blog_url { get; set; }
        public string github_id { get; set; }
        public string bio { get; set; }
        public object created { get; set; }
        public object modified { get; set; }
        public string active { get; set; }
        public string fullname { get; set; }

    }
}
