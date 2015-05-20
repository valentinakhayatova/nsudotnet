using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using TicTacToe.Models;

namespace TicTacToe.Converters
{
    public class UserToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is User))
            {
                return null;
            }
            switch ((User)value)
            {
                case User.Zero:
                    return ("pack://application:,,,/Assets/playO.png");
                    break;
                case User.Cross:
                    return ("pack://application:,,,/Assets/playX.png");
                    break;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}