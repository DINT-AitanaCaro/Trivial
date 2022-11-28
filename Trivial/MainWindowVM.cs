using System;
using System.Collections.Generic;
using System.Linq;
using Trivial.modelo;

namespace Trivial

{
    class MainWindowVM
    {
        private List<string> _dificultades;
        public List<string> Niveles
        {
            get { return _dificultades; }
            set { _dificultades = value; }
        }
        private List<string> _categorias;
        public List<string> Categorias
        {
            get { return _categorias; }
            set { _categorias = value; }
        }

        private Pregunta _nuevaPregunta;
        public Pregunta NuevaPregunta
        {
            get { return _nuevaPregunta; }
            set { _nuevaPregunta = value; }
        }
        public MainWindowVM()
        {
            _dificultades = Enum.GetNames(typeof(Pregunta.Dificultades)).ToList();
            _categorias = Enum.GetNames(typeof(Pregunta.Categorias)).ToList();
            NuevaPregunta = new Pregunta();
        }
    }
}
