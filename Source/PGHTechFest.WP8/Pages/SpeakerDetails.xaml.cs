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
    public partial class SpeakerDetails : BasePage
    {
        public static readonly DependencyProperty PresenterProperty =
            DependencyProperty.Register("Presenter", typeof(Presenter),
            typeof(BasePage), null);

        public Presenter Presenter
        {
            get { return this.GetValue(PresenterProperty) as Presenter; }
            set { this.SetValue(PresenterProperty, value); }
        }


        public SpeakerDetails()
        {
            if (System.ComponentModel.DesignerProperties.IsInDesignTool)
                Presenter = (new PGHTechFest.ViewModels.DesignViewModel()).Presenters.First();

            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.Presenter = DefaultViewModel.Presenters.First(x => x.id == NavigationContext.QueryString["id"]);
        }
    }
}