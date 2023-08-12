using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Views.Common.Converters
{
    /// <summary>
    /// Defines a converter that converts the given enum value to <see cref="Visibility"/>.
    /// </summary>
    public class EnumToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Gets the default converter instance.
        /// </summary>
        public static readonly EnumToVisibilityConverter Default = new EnumToVisibilityConverter();

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
