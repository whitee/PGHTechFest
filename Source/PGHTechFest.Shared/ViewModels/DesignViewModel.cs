using PGHTechFest.API.Models;
using PGHTechFest.API.Providers;
using System.Collections.ObjectModel;

namespace PGHTechFest.ViewModels
{
    public class DesignViewModel : MainViewModel
    {
        public DesignViewModel()
        {
            Initialize();
        }

        public override void Initialize()
        {
            PackageAPIProvider provider = new PackageAPIProvider();
            Presenters = new ObservableCollection<Presenter>(provider.GetPresenters());
            Sessions = new ObservableCollection<Session>(provider.GetSessions());
            Presentessions = new ObservableCollection<Presentession>(provider.GetPresentessions());
        }
    }
}
