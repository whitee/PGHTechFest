using System;
using System.Windows.Data;

namespace PGHTechFest.Converters
{
    public class UserToLinkConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "";

            switch (parameter.ToString().ToLower())
            {
                default: return "";
                case "blog": { return (!value.ToString().Contains("http://") ? "http://" : "") + value.ToString(); }
                case "github": { return "http://github.com/" + value.ToString(); }
                case "twitter": { return "http://twitter.com/" + value.ToString(); }
                case "twitter_image":
                    {
                        return (string.IsNullOrEmpty(value.ToString()))
                            ? ""
                            : "http://api.twitter.com/1/users/profile_image?screen_name=" + value.ToString() + "&size=bigger";
                    }

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
