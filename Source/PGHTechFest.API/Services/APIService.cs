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
        public EventHandler<APIQueryArgs> PresentationQueryComplete;
        public EventHandler<APIQueryArgs> Failure;

        private APIProvider _APIProvider;

        public APIService(APIProvider provider)
        {
            _APIProvider = provider;
        }

        async public void QueryPresenters()
        {
            List<Presenter> presenters = null;
            try
            {
                presenters = await _APIProvider.GetPresentersAsync();
            }
            catch (Exception ex)
            {
                if (Failure != null)
                    Failure.Invoke(this, new APIQueryArgs(ex));

                //TODO: Log Error
            }
            finally
            {
                if (PresenterQueryComplete != null)
                    PresenterQueryComplete.Invoke(this, new APIQueryArgs(presenters));
            }
        }

        async public void QuerySessions()
        {
            List<Session> sessions = null;
            try
            {
                sessions = await _APIProvider.GetSessionsAsync();
            }
            catch (Exception ex)
            {
                if (Failure != null)
                    Failure.Invoke(this, new APIQueryArgs(ex));

                //TODO: Log Error
            }
            finally
            {
                if (SessionQueryComplete != null)
                    SessionQueryComplete.Invoke(this, new APIQueryArgs(sessions));
            }
        }

        async public void QueryPresentations()
        {
            List<Presentation> presentations = null;
            try
            {
                presentations = await _APIProvider.GetPresentationsAsync();
            }
            catch(Exception ex)
            {
                if (Failure != null)
                    Failure.Invoke(this, new APIQueryArgs(ex));

                //TODO: Log Error
            }
            finally
            {
                if (PresentationQueryComplete != null)
                    PresentationQueryComplete.Invoke(this, new APIQueryArgs(presentations));
            }
        }
    }
}
