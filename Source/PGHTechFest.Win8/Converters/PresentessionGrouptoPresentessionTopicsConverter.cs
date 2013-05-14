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
    public class PresentessionGrouptoPresentessionTopicsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "";
            else
            {
                return (value as List<Presentession>).Aggregate<Presentession, string>("Presenters:", (a, b) => { return a + ((a.Length > 11) ? ", " : " ") + b.presenters_name; });
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
