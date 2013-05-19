using PGHTechFest.API.Models;
using PGHTechFest.API.Providers;
using PGHTechFest.API.Services;
using PGHTechFest.Common;
using System;
using System.Collections.ObjectModel;
using System.Linq;
#if NETFX_CORE
using Windows.UI.Xaml.Data;
#elif WINDOWS_PHONE
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.Generic;
#endif

namespace PGHTechFest.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private APIService _feedService;

        public EventHandler InitializationComplete;

        private bool _isSessionReady;
        private bool _isPresentessionReady;
        private bool _isPresenterReady;

        #region Properties
        public bool IsInitialized { get; set; }

        ObservableCollection<Presenter> _Presenters;
        public ObservableCollection<Presenter> Presenters
        {
            get { return _Presenters; }
            set { _Presenters = value; 
                OnPropertyChanged();
                CollectionViewSource presenterGroups = new CollectionViewSource();
#if NETFX_CORE
                presenterGroups.IsSourceGrouped = true;
                var letterGroups = from s in _Presenters
                                   orderby s.fullname ascending
                                   group s by s.fullname.ToUpper()[0] into g
                                   select new GroupInfoList<Presenter>(g.Key, g.ToList());
                presenterGroups.Source = letterGroups;
                PresenterGroups = presenterGroups.View;
#elif WINDOWS_PHONE
                var groupList = from p in _Presenters
                                orderby p.fullname ascending
                                group p by p.fullname.ToUpper()[0] into g 
                                select new Group<Presenter>(g.Key, g.ToList());

                PresenterGroups = new ObservableCollection<Group<Presenter>>(groupList.ToList());
#endif
            }
        }

        #if NETFX_CORE
        private ICollectionView _PresenterGroups;
        public ICollectionView PresenterGroups
        {
            get { return _PresenterGroups; }
            set { _PresenterGroups = value; OnPropertyChanged(); }
        }
        #elif WINDOWS_PHONE
        private ObservableCollection<Group<Presenter>> _PresenterGroups;
        public ObservableCollection<Group<Presenter>> PresenterGroups
        {
            get { return _PresenterGroups; }
            set { _PresenterGroups = value; OnPropertyChanged(); }
        }
        #endif

        ObservableCollection<Session> _Sessions;
        public ObservableCollection<Session> Sessions
        {
            get { return _Sessions; }
            set { 
                _Sessions = value;
                OnPropertyChanged();

                CollectionViewSource sessionGroups = new CollectionViewSource();
#if NETFX_CORE
                sessionGroups.IsSourceGrouped = true;
                var timeslotGroups = from s in _Sessions
                                    orderby s.track ascending
                                    group s by s.track into g
                                    select new GroupInfoList<Session>(g.Key, g.ToList());
                sessionGroups.Source = timeslotGroups;
                SessionGroups = sessionGroups.View;
#elif WINDOWS_PHONE
                var timeslotGroups = from s in _Sessions
                                     orderby s.track ascending
                                     group s by s.track into g
                                     select new Group<Session>(g.Key, g.ToList());

                SessionGroups = new ObservableCollection<Group<Session>>(timeslotGroups);
#endif
            }
        }

#if NETFX_CORE
        private ICollectionView _SessionGroups;
        public ICollectionView SessionGroups
        {
            get { return _SessionGroups; }
            set { _SessionGroups = value; OnPropertyChanged(); }
        }
#elif WINDOWS_PHONE
        private ObservableCollection<Group<Session>> _SessionGroups;
        public ObservableCollection<Group<Session>> SessionGroups
        {
            get { return _SessionGroups; }
            set { _SessionGroups = value; OnPropertyChanged(); }
        }
#endif

        ObservableCollection<Presentession> _Presentessions;
        public ObservableCollection<Presentession> Presentessions
        {
            get { return _Presentessions; }
            set { _Presentessions = value;
                OnPropertyChanged();
                CollectionViewSource sessionGroups = new CollectionViewSource();
#if NETFX_CORE
                sessionGroups.IsSourceGrouped = true;

                var timeslotGroups = from s in _Presentessions
                                     orderby s.time_sort ascending
                                     group s by s.time into g
                                     select new GroupInfoList<Presentession>(g.Key, g.ToList());
                sessionGroups.Source = timeslotGroups;
                PresentessionGroups = sessionGroups.View;
#elif WINDOWS_PHONE
                var timeslotGroups = from s in _Presentessions
                                     orderby s.time_sort ascending
                                     group s by s.time into g
                                     select new Group<Presentession>(g.Key, g.ToList());

                PresentessionGroups = new ObservableCollection<Group<Presentession>>(timeslotGroups);
#endif
            }
        }

#if NETFX_CORE
        private ICollectionView _PresentessionGroups;
        public ICollectionView PresentessionGroups
        {
            get { return _PresentessionGroups; }
            set { _PresentessionGroups = value; OnPropertyChanged(); }
        }
#elif WINDOWS_PHONE
        private ObservableCollection<Group<Presentession>> _PresentessionGroups;
        public ObservableCollection<Group<Presentession>> PresentessionGroups
        {
            get { return _PresentessionGroups; }
            set { _PresentessionGroups = value; OnPropertyChanged(); }
        }
#endif
        #endregion

        public MainViewModel()
        {
            _feedService = new APIService(new WebAPIProvider());
            _feedService.PresenterQueryComplete += PresenterQueryComplete_Handler;
            _feedService.SessionQueryComplete += SessionsQueryComplete_Handler;
            _feedService.PresentessionQueryComplete += PresentessionsQueryComplete_Handler;
            _isPresentessionReady = _isSessionReady = _isPresenterReady = false;
        }

        public void PresenterQueryComplete_Handler(object sender, APIQueryArgs e)
        {
            if (e.Presenters != null)
            {
                Presenters = new ObservableCollection<Presenter>(e.Presenters);
                _isPresenterReady = true;
            }
            else
                _isPresenterReady = false;

            CheckInitializationComplete();
        }

        public void SessionsQueryComplete_Handler(object sender, APIQueryArgs e)
        {
            if (e.Sessions != null)
            {
                Sessions = new ObservableCollection<Session>(e.Sessions);
                _isSessionReady = true;

            }
            else
                _isSessionReady = false;

            CheckInitializationComplete();
        }

        private void CheckInitializationComplete()
        {
            if (!IsInitialized && _isSessionReady && _isPresentessionReady && _isPresenterReady)
            {
                IsInitialized = true;
                if (InitializationComplete != null)
                    InitializationComplete.Invoke(this, null);
            }
            else
            {
                IsInitialized = false;
            }
        }

        public void PresentessionsQueryComplete_Handler(object sender, APIQueryArgs e)
        {
            if (e.Presentessions != null)
            {
                Presentessions = new ObservableCollection<Presentession>(e.Presentessions);
                _isPresentessionReady = true;
            }
            else
                _isPresentessionReady = false;

            CheckInitializationComplete();

        }

        public virtual void Initialize()
        {
            _feedService.QueryPresenters();
            _feedService.QuerySessions();
            _feedService.QueryPresentessions();
        }

    }
}
