using PGHTechFest.API.Models;
using PGHTechFest.API.Providers;
using PGHTechFest.API.Services;
using PGHTechFest.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PGHTechFest.DataModel
{
    public class FeedDataSource : BindableBase
    {
        private APIService _feedService;

        public EventHandler InitializationComplete;

        #region Properties
        public bool IsInitialized { get; set; }

        ObservableCollection<Presenter> _Presenters;
        public ObservableCollection<Presenter> Presenters
        {
            get { return _Presenters; }
            set { _Presenters = value; OnPropertyChanged(); }
        }

        ObservableCollection<Session> _Sessions;
        public ObservableCollection<Session> Sessions
        {
            get { return _Sessions; }
            set { 
                _Sessions = value;
                OnPropertyChanged();

                CollectionViewSource sessionGroups = new CollectionViewSource();
                sessionGroups.IsSourceGrouped = true;
                var timeslotGroups = from s in _Sessions
                                     orderby s.presenter ascending
                              group s by s.timeslot into g
                              select new GroupInfoList<Session>(g.Key, g.ToList());
                sessionGroups.Source = timeslotGroups;
                SessionGroups = sessionGroups.View;
            }
        }

        private ICollectionView _SessionGroups;
        public ICollectionView SessionGroups
        {
            get { return _SessionGroups; }
            set { _SessionGroups = value; OnPropertyChanged(); }
        }
        #endregion

        public FeedDataSource()
        {
            _feedService = new APIService(new WebAPIProvider());
            _feedService.PresenterQueryComplete += PresenterQueryComplete_Handler;
            _feedService.SessionQueryComplete += SessionsQueryComplete_Handler;
        }

        public void PresenterQueryComplete_Handler(object sender, APIQueryArgs e)
        {
            if (e.Presenters != null)
                Presenters = new ObservableCollection<Presenter>(e.Presenters);
            else
                IsInitialized = false;
        }

        public void SessionsQueryComplete_Handler(object sender, APIQueryArgs e)
        {
            if (e.Sessions != null)
            {
                Sessions = new ObservableCollection<Session>(e.Sessions);

                if (InitializationComplete != null)
                    InitializationComplete.Invoke(this, null);
            }
            else
                IsInitialized = false;

        }

        public void Initialize()
        {
            _feedService.QueryPresenters();
            _feedService.QuerySessions();
        }

    }
}
