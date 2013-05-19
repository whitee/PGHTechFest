using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PGHTechFest.API.Models
{
    [DataContract]
    public class PresentationFeed
    {
        [DataMember(Name="9:15 - 10:15")]
        public List<Presentation> Session1 { get; set; }
        [DataMember(Name="10:30 - 11:00")]
        public List<Presentation> Session2 { get; set; }
        [DataMember(Name="11:15 - 12:15")]
        public List<Presentation> Session3 { get; set; }
        [DataMember(Name="1:15 - 1:45")]
        public List<Presentation> Session4 { get; set; }
        [DataMember(Name="2:00 - 3:00")]
        public List<Presentation> Session5 { get; set; }
        [DataMember(Name="2:00 - 4:30")]
        public List<Presentation> Session6 { get; set; }
        [DataMember(Name = "3:30 - 4:30")]
        public List<Presentation> Session7 { get; set; }
        [IgnoreDataMember]
        public List<Presentation> AllSessions { get { return Session1.Union(Session2).Union(Session3).Union(Session4).Union(Session5).Union(Session6).Union(Session7).ToList(); } }
    }
}
