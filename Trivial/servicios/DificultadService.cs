using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDePreguntas.servicios
{
    class DificultadService
    {
        public List<string> getDificultades()
        {
            return new List<string> { "Fácil", "Media", "Dificil" };
        }
    }
}
