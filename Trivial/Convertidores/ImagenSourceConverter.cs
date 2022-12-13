using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Trivial.modelo;

namespace Trivial.Convertidores
{
    class ImagenSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string dir = Directory.GetCurrentDirectory() + "/../../assets/";
            if (value != null)
            {
                string categoria = value.ToString();
                switch (categoria)
                {
                    case "Disney": return new BitmapImage(new Uri(dir + "disney.png"));
                    case "Pixar": return new BitmapImage(new Uri(dir + "pixar.png"));
                    case "Marvel": return new BitmapImage(new Uri(dir + "marvel.png"));
                    case "DC": return new BitmapImage(new Uri(dir + "dc.png"));
                    case "Fácil": return new BitmapImage(new Uri(dir + "facil.png"));
                    case "Media": return new BitmapImage(new Uri(dir + "media.png"));
                    case "Difícil": return new BitmapImage(new Uri(dir + "dificil.png"));
                    default: return new BitmapImage(new Uri(dir + "interrogation-mark.png"));
                }
            } else
            {
                return new BitmapImage(new Uri(dir + "interrogation-mark.png"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
