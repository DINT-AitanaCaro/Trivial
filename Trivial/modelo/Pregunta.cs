using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivial.modelo
{
    class Pregunta : ObservableObject
    {
        public Pregunta()
        { }

        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set { SetProperty(ref _texto, value); }
        }

        private string _respuesta;
        public string Respuesta
        {
            get { return _respuesta; }
            set { SetProperty(ref _respuesta, value); }
        }

        private string _imagen;
        public string Imagen
        {
            get { return _imagen; }
            set { SetProperty(ref _imagen, value); }
        }

        public enum Dificultades { Facil, Medio, Dificil};
        public enum Categorias { Disney, Pixar, Villanos, EasterEggs };
        private Dificultades _dificultad;
        public Dificultades Dificultad
        {
            get { return _dificultad; }
            set { SetProperty(ref _dificultad, value); }
        }
    }
}
