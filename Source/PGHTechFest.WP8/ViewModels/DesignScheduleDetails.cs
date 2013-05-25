using PGHTechFest.API.Models;
using PGHTechFest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGHTechFest.ViewModels
{
    public class DesignScheduleDetails : BindableBase
    {
        Session _ScheduledItem;
        public Session ScheduledItem
        {
            get { return _ScheduledItem; }
            set { _ScheduledItem = value; OnPropertyChanged(); }
        }

        private Presenter _Presenter;
        public Presenter Presenter
        {
            get { return _Presenter; }
            set { _Presenter = value; OnPropertyChanged(); }
        }
 
        public DesignScheduleDetails()
        {
            this.ScheduledItem = PGHTechFest.API.DesignHelper.Get_Session_37();
            this.Presenter = PGHTechFest.API.DesignHelper.Get_Hector_Correa();
        }
    }
}
