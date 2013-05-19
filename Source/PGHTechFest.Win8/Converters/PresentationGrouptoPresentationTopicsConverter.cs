using PGHTechFest.API.Models;
using PGHTechFest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PGHTechFest.Converters
{
    public class PresentationGrouptoPresentationTopicsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "";
            else
            {
                return (value as List<Presentation>).Aggregate<Presentation, string>("Presenters:", (a, b) => { return a + ((a.Length > 11) ? ", " : " ") + b.presenters_name; });
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
