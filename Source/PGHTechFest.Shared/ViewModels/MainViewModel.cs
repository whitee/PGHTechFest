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
        public EventHandler InitializationError;

        private bool _isSessionReady;
        private bool _isPresentationReady;
        private bool _isPresenterReady;

        #region Properties
        private bool _IsInitialized;
        public bool IsInitialized { get { return _IsInitialized; } set { _IsInitialized = value; OnPropertyChanged(); } }

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

        ObservableCollection<Presentation> _Presentations;
        public ObservableCollection<Presentation> Presentations
        {
            get { return _Presentations; }
            set { _Presentations = value;
                OnPropertyChanged();
                CollectionViewSource sessionGroups = new CollectionViewSource();
#if NETFX_CORE
                sessionGroups.IsSourceGrouped = true;

                var timeslotGroups = from s in _Presentations
                                     orderby s.time_sort ascending
                                     group s by s.time into g
                                     select new GroupInfoList<Presentation>(g.Key, g.ToList());
                sessionGroups.Source = timeslotGroups;
                PresentationGroups = sessionGroups.View;
#elif WINDOWS_PHONE
                var timeslotGroups = from s in _Presentations
                                     orderby s.time_sort ascending
                                     group s by s.time into g
                                     select new Group<Presentation>(g.Key, g.ToList());

                PresentationGroups = new ObservableCollection<Group<Presentation>>(timeslotGroups);
#endif
            }
        }

#if NETFX_CORE
        private ICollectionView _PresentationGroups;
        public ICollectionView PresentationGroups
        {
            get { return _PresentationGroups; }
            set { _PresentationGroups = value; OnPropertyChanged(); }
        }
#elif WINDOWS_PHONE
        private ObservableCollection<Group<Presentation>> _PresentationGroups;
        public ObservableCollection<Group<Presentation>> PresentationGroups
        {
            get { return _PresentationGroups; }
            set { _PresentationGroups = value; OnPropertyChanged(); }
        }
#endif
        #endregion

        public MainViewModel()
        {
            _feedService = new APIService(new WebAPIProvider());
            _feedService.PresenterQueryComplete += PresenterQueryComplete_Handler;
            _feedService.SessionQueryComplete += SessionsQueryComplete_Handler;
            _feedService.PresentationQueryComplete += PresentationsQueryComplete_Handler;
            _feedService.Failure += Failure_Handler;
            _isPresentationReady = _isSessionReady = _isPresenterReady = false;
        }

        private void PresenterQueryComplete_Handler(object sender, APIQueryArgs e)
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

        private void SessionsQueryComplete_Handler(object sender, APIQueryArgs e)
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
            //TODO: Clean up state.  Add Updating property that binds to progressbar 
            if ((!IsInitialized && _isSessionReady && _isPresentationReady && _isPresenterReady) || _errorInitializing)
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

        private void PresentationsQueryComplete_Handler(object sender, APIQueryArgs e)
        {
            if (e.Presentations != null)
            {
                Presentations = new ObservableCollection<Presentation>(e.Presentations);
                _isPresentationReady = true;
            }
            else
                _isPresentationReady = false;

            CheckInitializationComplete();

        }

        private void Failure_Handler(object sender, APIQueryArgs e)
        {
            if (!_errorInitializing)
            {
                //TODO: lock this
                _errorInitializing = true;

                if (InitializationError != null)
                    InitializationError.Invoke(this, null);
            }

            //TODO: Display something useful.  Cached data for example.

            System.Diagnostics.Debug.WriteLine(string.Format("Initialization error. [{0}]", e.Error.Message));
        }

        public virtual void Initialize()
        {
            _errorInitializing = false;
            _feedService.QueryPresenters();
            _feedService.QuerySessions();
            _feedService.QueryPresentations();
        }


        public bool _errorInitializing { get; set; }
    }
}
