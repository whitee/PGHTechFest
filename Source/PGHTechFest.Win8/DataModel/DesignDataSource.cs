using PGHTechFest.API.Models;
using PGHTechFest.API.Providers;
using PGHTechFest.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGHTechFest.DataModel
{
    public class DesignDataSource : FeedDataSource
    {
        public DesignDataSource()
        {
            Initialize();
        }

        private void Initialize()
        {
            PackageAPIProvider provider = new PackageAPIProvider();
            Presenters = new ObservableCollection<Presenter>(provider.GetPresenters());
            Sessions = new ObservableCollection<Session>(provider.GetSessions());
        }
    }
}
