using System;
using System.Globalization;
using Xamarin.Forms;

namespace UserApp.Common
{
    public class CostValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cost = (double)value;
            return $"{cost:0.00}$";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
