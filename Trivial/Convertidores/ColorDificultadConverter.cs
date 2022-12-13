using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Trivial.Convertidores
{
    class ColorDificultadConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                BrushConverter bc = new BrushConverter(); 
                switch (value.ToString())
                {
                    case "Fácil": return bc.ConvertFromString("#00FF00");
                    case "Media": return bc.ConvertFromString("#FFA500");
                    case "Difícil": return bc.ConvertFromString("#FF0000");
                    default: return bc.ConvertFromString("#000000");
                }
            } else { return Brushes.Transparent; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
