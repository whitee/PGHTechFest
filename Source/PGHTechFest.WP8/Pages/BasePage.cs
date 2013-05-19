using Microsoft.Phone.Controls;
using PGHTechFest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PGHTechFest.Pages
{
    public class BasePage : PhoneApplicationPage
    {
        /// <summary>
        /// Identifies the <see cref="DefaultViewModel"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DefaultViewModelProperty =
            DependencyProperty.Register("DefaultViewModel", typeof(MainViewModel),
            typeof(BasePage), null);


        /// <summary>
        /// An implementation of <see cref="IObservableMap&lt;String, Object&gt;"/> designed to be
        /// used as a trivial view model.
        /// </summary>
        protected MainViewModel DefaultViewModel
        {
            get { return this.GetValue(DefaultViewModelProperty) as MainViewModel; }
            set { this.SetValue(DefaultViewModelProperty, value); }
        }


        public BasePage()
        {
            // Create an empty default view model
            this.DefaultViewModel = Application.Current.Resources["DataSource"] as MainViewModel;

            if (!DefaultViewModel.IsInitialized)
                DefaultViewModel.Initialize();
        }

        public void Sessions_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Sessions.xaml", UriKind.Relative));
        }

        public void Speakers_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Speakers.xaml", UriKind.Relative));
        }

        public void Schedule_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Schedule.xaml", UriKind.Relative));
        }
    }
}
