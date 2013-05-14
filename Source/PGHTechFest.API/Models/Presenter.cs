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
        private string _twitter;
        public string twitter
        {
            get { return DecorateTwitterHandle(_twitter); }
            set { _twitter = value; }
        }

        private string DecorateTwitterHandle(string _twitter)
        {
            if(!string.IsNullOrWhiteSpace(_twitter) && _twitter[0] != '@')
                return "@" + _twitter;
            else
                return _twitter;
        }
        public string blog_url { get; set; }
        public string github_id { get; set; }
        public string bio { get; set; }
        public object created { get; set; }
        public object modified { get; set; }
        public string active { get; set; }
        public string fullname { get; set; }

    }
}
