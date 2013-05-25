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
    public partial class ScheduleItem : BasePage
    {

        public static readonly DependencyProperty ScheduledItemProperty =
            DependencyProperty.Register("ScheduledItem", typeof(Presentation),
            typeof(BasePage), null);

        public Presentation ScheduledItem
        {
            get { return this.GetValue(ScheduledItemProperty) as Presentation; }
            set { this.SetValue(ScheduledItemProperty, value); }
        }

        public static readonly DependencyProperty PresenterProperty =
            DependencyProperty.Register("Presenter", typeof(Presenter),
            typeof(BasePage), null);

        public Presenter Presenter
        {
            get { return this.GetValue(PresenterProperty) as Presenter; }
            set { this.SetValue(PresenterProperty, value); }
        }

        public ScheduleItem()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.IsInDesignTool)
            {
                ScheduledItem = (new PGHTechFest.ViewModels.DesignViewModel()).Presentations.First();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.ScheduledItem = DefaultViewModel.Presentations.First(x => x.id == NavigationContext.QueryString["id"]);
            if (DefaultViewModel.IsInitialized)
            {
                UpdatePresenterBinding();
            }
            else
            {
                DefaultViewModel.InitializationComplete += delegate { UpdatePresenterBinding(); };
            }
        }

        private void UpdatePresenterBinding()
        {
            this.Presenter = DefaultViewModel.Presenters.First(x => x.id == ScheduledItem.presenter_id);
            ApplicationBarIconButton button = this.ApplicationBar.Buttons[0] as ApplicationBarIconButton;
            button.Text = ScheduledItem.presenters_name;
        }

        private void PresenterName_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SpeakerDetails.xaml?id=" + ScheduledItem.presenter_id, UriKind.Relative));
        }

        public void Presenter_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SpeakerDetails.xaml?id=" + ScheduledItem.presenter_id, UriKind.Relative));
        }
    }
}