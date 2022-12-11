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

        private bool _disneyAdivinado;
        public bool DisneyAdivinado
        {
            get { return _disneyAdivinado; }
            set { SetProperty(ref _disneyAdivinado, value); }
        }

        private bool _pixarAdivinado;
        public bool PixarAdivinado
        {
            get { return _pixarAdivinado; }
            set { SetProperty(ref _pixarAdivinado, value); }
        }

        private bool _marvelAdivinado;
        public bool MarvelAdivinado
        {
            get { return _marvelAdivinado; }
            set { SetProperty(ref _marvelAdivinado, value); }
        }

        private bool _dcAdivinado;
        public bool DcAdivinado
        {
            get { return _dcAdivinado; }
            set { SetProperty(ref _dcAdivinado, value); }
        }
    }
}
