using Newtonsoft.Json;
using PGHTechFest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGHTechFest.API.Providers
{
    public class MockAPIProvider : PGHTechFest.API.Providers.APIProvider
    {
        #region Presenters
        public Task<List<Presenter>> GetPresentersAsync()
        {
            return TaskEx.Run<List<Presenter>>(() =>
            {
                return new List<Presenter>()
                {
                    DesignHelper.Get_Hector_Correa(),
                    DesignHelper.Get_Constantine_Aaron_Cois()
                };
            });
        }

        public List<Presenter> GetPresenters()
        {
            return new List<Presenter>()
            {
                DesignHelper.Get_Hector_Correa(),
                DesignHelper.Get_Constantine_Aaron_Cois()
            };
        }
        #endregion

        #region Sessions
        public Task<List<Session>> GetSessionsAsync()
        {
            return TaskEx.Run<List<Session>>(() =>
            {
                return new List<Session>()
                {
                    DesignHelper.Get_Session_37(),
                    DesignHelper.Get_Session_38()
                };
            });
        }

        public List<Session> GetSessions()
        {
            return new List<Session>()
            {
                DesignHelper.Get_Session_37(),
                DesignHelper.Get_Session_38()
            };
        }
        #endregion

        public Task<List<Presentation>> GetPresentationsAsync()
        {
            return TaskEx.Run<List<Presentation>>(() =>
            {
                return DesignHelper.Get_Session1();
            });
        }

        public List<Presentation> GetPresentations()
        {
            return DesignHelper.Get_Session1();
        }

    }
}
