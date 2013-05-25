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
        private string _presentation_list_uri = "http://pghtechfest.com/sessions-presenters.json";

        public WebAPIProvider()
        { }

        async public Task<List<Presenter>> GetPresentersAsync()
        {
            try
            {
                var result = await GetDataAsync<PresentersFeed>(_presenters_uri);
                return result.Presenters;
            }
            catch (Exception ex)
            {
                return null;
            }
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

        async public Task<List<Presentation>> GetPresentationsAsync()
        {
            HttpClient client = new HttpClient();
            string payload = await client.GetStringAsync(_presentation_list_uri);

            if (!string.IsNullOrWhiteSpace(payload))
                return JsonConvert.DeserializeObject<PresentationFeed>(payload).AllSessions;
            else
                return null;
        }


        async public Task<T> GetDataAsync<T>(string url)
        {
            HttpClient client = new HttpClient();
            string payload;

            try
            {
                payload = await client.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                throw ex;

                //rethrow for now
            }

            if (!string.IsNullOrWhiteSpace(payload))
                return JsonConvert.DeserializeObject<T>(payload);
            else
                throw new InvalidOperationException("Error deserializing the feed.  Check the request response format");
        }
    }
}
