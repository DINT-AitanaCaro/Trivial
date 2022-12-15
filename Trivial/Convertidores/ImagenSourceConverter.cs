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
            string dir = "https://trivialaitana.blob.core.windows.net/trivial/interrogation-mark.png";
            if (value != null)
            {
                string categoria = value.ToString();
                switch (categoria)
                {
                    case "Disney":
                        dir = "https://trivialaitana.blob.core.windows.net/trivial/disney.png";
                        break;
                    case "Pixar":
                        dir = "https://trivialaitana.blob.core.windows.net/trivial/pixar.png";
                        break;
                    case "Marvel":
                        dir = "https://trivialaitana.blob.core.windows.net/trivial/marvel.png";
                        break;
                    case "DC":
                        dir = "https://trivialaitana.blob.core.windows.net/trivial/dc.png";
                        break;
                }
            }
                return new BitmapImage(new Uri(dir));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
