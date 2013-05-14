using System;
using System.Threading.Tasks;
namespace PGHTechFest.API.Providers
{
    public interface APIProvider
    {
        Task<System.Collections.Generic.List<PGHTechFest.API.Models.Presenter>> GetPresentersAsync();
        Task<System.Collections.Generic.List<PGHTechFest.API.Models.Session>> GetSessionsAsync();
        Task<System.Collections.Generic.List<PGHTechFest.API.Models.Presentession>> GetPresentessionsAsync();
    }
}
