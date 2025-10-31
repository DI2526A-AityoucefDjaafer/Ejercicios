using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Superheroes.Converters
{
    public class GruposToLogosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var logos = new List<BitmapImage>();

            if (value is Superheroes.Superheroe personaje)
            {
                if (personaje.Vengador)
                {
                    logos.Add(new BitmapImage(new Uri("Assets/avengers.png", UriKind.Relative)));
                }

                if (personaje.Xmen)
                {
                    logos.Add(new BitmapImage(new Uri("Assets/xmen.png", UriKind.Relative)));
                }
            }

            return logos;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
