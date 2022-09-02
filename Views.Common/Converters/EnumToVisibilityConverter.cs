using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Views.Common.Converters
{
    public class EnumToVisibilityConverter : IValueConverter
    {
        public static readonly EnumToVisibilityConverter Default = new EnumToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum && parameter is Enum)
            {
                if (value.Equals(parameter))
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
