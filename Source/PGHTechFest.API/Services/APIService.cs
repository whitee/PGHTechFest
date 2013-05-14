using PGHTechFest.API.Models;
using PGHTechFest.API.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGHTechFest.API.Services
{
    public class APIService
    {

        public EventHandler<APIQueryArgs> PresenterQueryComplete;
        public EventHandler<APIQueryArgs> SessionQueryComplete;
        public EventHandler<APIQueryArgs> PresentessionQueryComplete;
        private APIProvider _APIProvider;

        public APIService(APIProvider provider)
        {
            _APIProvider = provider;
        }

        async public void QueryPresenters()
        {
            if (PresenterQueryComplete != null)
                PresenterQueryComplete.Invoke(this, new APIQueryArgs(await _APIProvider.GetPresentersAsync()));
        }

        async public void QuerySessions()
        {
            if (SessionQueryComplete != null)
                SessionQueryComplete.Invoke(this, new APIQueryArgs(await _APIProvider.GetSessionsAsync()));
        }

        async public void QueryPresentessions()
        {
            if (PresentessionQueryComplete != null)
                PresentessionQueryComplete.Invoke(this, new APIQueryArgs(await _APIProvider.GetPresentessionsAsync()));
        }
    }
}
