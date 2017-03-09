using System;
using System.Globalization;
using Xamarin.Forms;

namespace UserApp.Common.Converters
{
    public class ConverterToNullValue : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}