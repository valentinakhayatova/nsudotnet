using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TicTacToe.Converters
{
    public class IsActiveToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                return null;
            }

            if ((bool) value)
            {
                return new SolidColorBrush(Colors.Salmon);
            }
            else
            {
                return new SolidColorBrush(Colors.SkyBlue);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}