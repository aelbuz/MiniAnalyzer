using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Views.Common.Converters
{
    /// <summary>
    /// Defines a converter that converts the given <see cref="bool"/> value to <see cref="Visibility"/>.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        private readonly bool isInverted;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanToVisibilityConverter"/> class.
        /// </summary>
        /// <param name="isInverted">The converter is inverted or not.</param>
        /// <remarks>
        /// If the converter is inverted;
        /// <c>true</c> returns <see cref="Visibility.Collapsed"/> and
        /// <c>false</c> returns <see cref="Visibility.Visible"/>.
        /// <para/>
        /// If the converter is not inverted;
        /// <c>true</c> returns <see cref="Visibility.Visible"/> and
        /// <c>false</c> returns <see cref="Visibility.Collapsed"/>.
        /// </remarks>
        public BooleanToVisibilityConverter(bool isInverted)
        {
            this.isInverted = isInverted;
        }

        /// <summary>
        /// Gets the default converter instance.
        /// </summary>
        public static readonly BooleanToVisibilityConverter Default = new BooleanToVisibilityConverter(false);

        /// <summary>
        /// Gets the default inverted converter instance.
        /// </summary>
        public static readonly BooleanToVisibilityConverter DefaultInverted = new BooleanToVisibilityConverter(true);

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? b = value as bool?;

            if (b == null)
            {
                return isInverted ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                if (isInverted)
                {
                    return b.Value ? Visibility.Collapsed : Visibility.Visible;
                }
                else
                {
                    return b.Value ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
