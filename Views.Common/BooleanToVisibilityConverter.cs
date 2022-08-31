﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Views.Common
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        private readonly bool isInverted;

        public BooleanToVisibilityConverter(bool isInverted)
        {
            this.isInverted = isInverted;
        }

        public static BooleanToVisibilityConverter Default = new BooleanToVisibilityConverter(false);
        public static BooleanToVisibilityConverter Inverted = new BooleanToVisibilityConverter(true);

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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}