using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PGHTechFest.API.Models;

namespace PGHTechFest.Pages
{
    public partial class Schedule : BasePage
    {
        public Schedule()
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


        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScheduleList.SelectedItem == null)
                return;

            var selectedData = ScheduleList.SelectedItem as Presentation;
            NavigationService.Navigate(new Uri("/Pages/ScheduleItem.xaml?id=" + selectedData.id, UriKind.Relative));

            ScheduleList.SelectedItem = null;
        }
    }
}