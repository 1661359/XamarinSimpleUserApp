using System;
using System.Globalization;
using Xamarin.Forms;

namespace UserApp.Common
{
    public class DistanceValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var distance = (double)value;
            return $"{distance:N2} mi";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}