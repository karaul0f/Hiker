using System;
using System.Globalization;
using System.Numerics;
using System.Windows;
using System.Windows.Data;

namespace HikerEditor.Views.Converters
{
    /// <summary>
    /// Конвертер Null значения в параметр невидимости
    /// </summary>
    public class Vector2ToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVector = value is Vector2;

            if (isVector)
            {
                Vector2 v = (Vector2)value;
                return $"({v.X} : {v.Y})";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
