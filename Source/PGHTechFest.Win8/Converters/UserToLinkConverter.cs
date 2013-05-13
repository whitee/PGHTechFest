using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PGHTechFest.Converters
{
    public class UserToLinkConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "";

            switch(parameter.ToString().ToLower())
            {
                default: return "";
                case "blog": { return (!value.ToString().Contains("http://") ? "http://" : "") + value.ToString(); }
                case "github": { return "http://github.com/" + value.ToString(); }
                case "twitter": { return "http://twitter.com/" + value.ToString(); }
                case "twitter_image": {  return (string.IsNullOrEmpty(value.ToString())) 
                    ? "" 
                    : "https://api.twitter.com/1/users/profile_image?screen_name=" + value.ToString() + "&size=bigger;"; 
                }
                    
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
