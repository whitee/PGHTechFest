using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PGHTechFest.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Speakers : PGHTechFest.Common.LayoutAwarePage
    {
        Windows.UI.ApplicationSettings.SettingsPane _settingsPane;

        public Speakers()
        {
            this.InitializeComponent();

            _settingsPane = Windows.UI.ApplicationSettings.SettingsPane.GetForCurrentView();

            Windows.UI.ApplicationSettings.SettingsPane.GetForCurrentView().CommandsRequested += App_CommandsRequested;
            
            if (DefaultViewModel.IsInitialized)
            {
                SetZoomedOutViewItemsSource();
            }
            else
            {
                DefaultViewModel.InitializationComplete += delegate(object s, EventArgs e)
                {
                    SetZoomedOutViewItemsSource();
                };
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _settingsPane.CommandsRequested += App_CommandsRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _settingsPane.CommandsRequested -= App_CommandsRequested;
            base.OnNavigatedFrom(e);
        }

        private void App_CommandsRequested(Windows.UI.ApplicationSettings.SettingsPane sender, Windows.UI.ApplicationSettings.SettingsPaneCommandsRequestedEventArgs args)
        {
            if (args.Request.ApplicationCommands.Count < 1)
            {
                args.Request.ApplicationCommands.Add(new Windows.UI.ApplicationSettings.SettingsCommand("privacy", "Privacy Policy", x =>
                {
                    Frame.Navigate(typeof(About));
                }));
            }
        }


        private void SetZoomedOutViewItemsSource()
        {
            if (DefaultViewModel.PresenterGroups != null)
                (SessionZoom.ZoomedOutView as ListViewBase).ItemsSource = DefaultViewModel.PresenterGroups.CollectionGroups;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
    }
}
