using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Superheroes.Converters
{
    public class HeroeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool esHeroe = (bool)value;
            return esHeroe ? Brushes.Aquamarine : Brushes.IndianRed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}