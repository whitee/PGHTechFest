using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PGHTechFest.API.Models
{
    [DataContract]
    public class PresentessionFeed
    {
        [DataMember(Name="9:15 - 10:15")]
        public List<Presentession> Session1 { get; set; }
        [DataMember(Name="10:30 - 11:00")]
        public List<Presentession> Session2 { get; set; }
        [DataMember(Name="11:15 - 12:15")]
        public List<Presentession> Session3 { get; set; }
        [DataMember(Name="1:15 - 1:45")]
        public List<Presentession> Session4 { get; set; }
        [DataMember(Name="2:00 - 3:00")]
        public List<Presentession> Session5 { get; set; }
        [DataMember(Name="2:00 - 4:30")]
        public List<Presentession> Session6 { get; set; }
        [DataMember(Name = "3:30 - 4:30")]
        public List<Presentession> Session7 { get; set; }
        [IgnoreDataMember]
        public List<Presentession> AllSessions { get { return Session1.Union(Session2).Union(Session3).Union(Session4).Union(Session5).Union(Session6).Union(Session7).ToList(); } }
    }
}
