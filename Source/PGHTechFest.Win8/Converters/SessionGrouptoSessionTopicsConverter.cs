using PGHTechFest.API.Models;
using PGHTechFest.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PGHTechFest.Converters
{
    public class SessionGrouptoSessionTopicsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "";
            else
            {
                return (value as List<Session>).Aggregate<Session,string>("Presenters:", (a, b) => { return a + ((a.Length > 11) ? ", " : " ") + b.presenter; });
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
