using Newtonsoft.Json;
using PGHTechFest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PGHTechFest.API.Providers
{
    public class WebAPIProvider : APIProvider
    {
        private string _presenters_uri = "http://pghtechfest.com/presenters.json";
        private string _session_list_uri = "http://pghtechfest.com/session_list.json";
        private string _presentession_list_uri = "http://pghtechfest.com/sessions-presenters.json";

        public WebAPIProvider()
        { }

        async public Task<List<Presenter>> GetPresentersAsync()
        {
            HttpClient client = new HttpClient();
            string payload = await client.GetStringAsync(_presenters_uri);
            
            if (!string.IsNullOrWhiteSpace(payload))
                return JsonConvert.DeserializeObject<PresentersFeed>(payload).Presenters;
            else
                return null;
        }

        async public Task<List<Session>> GetSessionsAsync()
        {
            HttpClient client = new HttpClient();
            string payload = await client.GetStringAsync(_session_list_uri);

            if (!string.IsNullOrWhiteSpace(payload))
                return JsonConvert.DeserializeObject<SessionsFeed>(payload).Sessions;
            else
                return null;
        }

        async public Task<List<Presentession>> GetPresentessionsAsync()
        {
            HttpClient client = new HttpClient();
            string payload = await client.GetStringAsync(_presentession_list_uri);

            if (!string.IsNullOrWhiteSpace(payload))
                return JsonConvert.DeserializeObject<PresentessionFeed>(payload).AllSessions;
            else
                return null;
        }
    }
}
