using PGHTechFest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGHTechFest.API.Services
{
    public class APIQueryArgs : EventArgs
    {
        public List<Presenter> Presenters {get;set;}
        public List<Session> Sessions { get; set; }
        public List<Presentation> Presentations { get; set; }

        public APIQueryArgs(List<Presenter> presenters)
        {
            Presenters = presenters;
        }

        public APIQueryArgs(List<Session> sessions)
        {
            Sessions = sessions;
        }

        public APIQueryArgs(List<Presentation> presentations)
        {
            Presentations = presentations;
        }
    }
}
