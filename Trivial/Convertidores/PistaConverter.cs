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
            string respuesta = value.ToString();
            string pista = "";
            Random rnd = new Random();
            int numCodificado = respuesta.Length / 2;
            if (value.ToString().Length > 1)
            {
                for (int i = 0; i < respuesta.Length; i++)
                {
                    if (respuesta[i] != ' ')
                    {
                        if ((rnd.Next(2) == 1 && numCodificado > 0) || (respuesta.Length - i - 1 < numCodificado))
                        {
                            pista += '*';
                            numCodificado--;
                        }
                        else
                        {
                            pista += respuesta[i];
                        }
                    }
                    else pista += ' ';
                }
            } else
            {
                pista = "*";
            }
            return pista;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
