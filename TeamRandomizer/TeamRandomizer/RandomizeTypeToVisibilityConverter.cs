using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Randomizer;
using Randomizer.Data;

namespace TeamRandomizer
{
    public class RandomizeTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (RandomizeType)value == RandomizeType.Simple ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value ==Visibility.Collapsed ? RandomizeType.Simple : RandomizeType.Grouped;
        }
    }
}
