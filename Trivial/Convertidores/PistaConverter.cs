using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Trivial.Convertidores
{
    class PistaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string pista = "";
            Random rnd = new Random();
            //int num = rnd.Next(0, PreguntaActual.Respuesta.Length);
            foreach (char c in value.ToString())
            {
                if (c != ' ')
                {
                    if (rnd.Next(2) == 0)
                    {
                        pista += '*';
                    }
                    else
                    {
                        pista += c;
                    }
                }
                else pista += ' ';
            }
            return pista;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
