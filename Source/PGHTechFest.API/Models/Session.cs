using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGHTechFest.API.Models
{
    /// <summary>
    /// Created using http://json2csharp.com/
    /// </summary>
    public class Session
    {
        public string id { get; set; }
        public string title { get; set; }
        public string track { get; set; }
        public string timeslot { get; set; }
        public string timeslot_id { get; set; }
        public string presenter { get; set; }
        public string presenter_id { get; set; }
        public string description { get; set; }
        public string length { get; set; }
        public string room { get; set; }
        public object notes { get; set; }
        public object created { get; set; }
        public object modified { get; set; }
        public string active { get; set; }
        public object track_id { get; set; }

        public void Copy(Session obj)
        {
            this.active = obj.active;
            this.created = obj.created;
            this.description = obj.description;
            this.id = obj.id;
            this.length = obj.id;
            this.modified = obj.modified;
            this.notes = obj.notes;
            this.presenter = obj.presenter;
            this.presenter_id = obj.presenter_id;
            this.room = obj.room;
            this.timeslot = obj.timeslot;
            this.timeslot_id = obj.timeslot_id;
            this.title = obj.title;
            this.track = obj.track;
            this.track_id = obj.track_id;
        }
    }
}
