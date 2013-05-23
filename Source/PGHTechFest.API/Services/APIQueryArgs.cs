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
        public Exception Error { get; set; }

        public APIQueryArgs(Exception error)
        {
            Error = error;
        }

        public APIQueryArgs(List<Presenter> presenters, Exception error = null)
        {
            Presenters = presenters;
            Error = error;
        }

        public APIQueryArgs(List<Session> sessions, Exception error = null)
        {
            Sessions = sessions;
            Error = error;
        }

        public APIQueryArgs(List<Presentation> presentations, Exception error = null)
        {
            Presentations = presentations;
            Error = error;
        }
    }
}
