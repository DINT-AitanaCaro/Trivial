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
        {
            Imagen = "image_not_found.png";
        }

        public Pregunta(string texto, string respuesta, string imagen, string dificultad, string categoria)
        {
            _texto = texto;
            _respuesta = respuesta;
            _imagen = imagen;
            _dificultad = dificultad;
            _categoria = categoria;
        }

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
            set { SetProperty(ref _imagen, value == null ? "image_not_found.png" : value); }
        }

        private string _dificultad;
        public string Dificultad
        {
            get { return _dificultad; }
            set { SetProperty(ref _dificultad, value); }
        }

        private string _categoria;
        public string Categoria
        {
            get { return _categoria; }
            set { SetProperty(ref _categoria, value); }
        }
        public override string ToString()
        {
            return $"preg: {Texto} \nres: {Respuesta}";
        }
    }
}
