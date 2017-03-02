using System;
using System.Globalization;
using Xamarin.Forms;

namespace UserApp.Common
{
    public class TimeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (TimeSpan) value;
            return DateTime.Today.Add(time).ToString("hh:mm tt", CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}