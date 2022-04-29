﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HikerEditor.Views.Converters
{
    /// <summary>
    /// Конвертер Null значения в параметр невидимости
    /// </summary>
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
