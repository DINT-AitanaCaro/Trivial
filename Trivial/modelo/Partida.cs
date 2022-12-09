using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivial.modelo
{
    class Partida : ObservableObject
    {
        public Partida()
        {
            Preguntas = new List<Pregunta>();
        }
        public Partida(string dificultad)
        {
            Preguntas = new List<Pregunta>();
            Dificultad = dificultad;
        }

        private string _dificultad;
        public string Dificultad
        {
            get { return _dificultad; }
            set { SetProperty(ref _dificultad,value); }
        }

        private List<Pregunta> _preguntas;

        public List<Pregunta> Preguntas
        {
            get { return _preguntas; }
            set { SetProperty(ref _preguntas,value); }
        }

    }
}
