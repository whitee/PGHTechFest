using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace PGHTechFest.Pages
{
    public partial class Speakers : BasePage
    {
        public Speakers()
        {
            InitializeComponent();
        }

        public void Sessions_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Sessions.xaml", UriKind.Relative));
        }

        public void Speakers_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Speakers.xaml", UriKind.Relative));
        }

        public void Schedule_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Schedule.xaml", UriKind.Relative));
        }

        public void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/About.xaml", UriKind.Relative));
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            string uri = (sender as FrameworkElement).Tag as string;
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri(uri, UriKind.Absolute);
            task.Show();
        }
    }
}