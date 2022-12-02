using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trivial.modelo;
using Trivial.servicios;

namespace Trivial

{
    class MainWindowVM : ObservableObject
    {
        private List<string> _dificultades;
        public List<string> Niveles
        {
            get { return _dificultades; }
            set { SetProperty(ref _dificultades, value); }
        }
        private List<string> _categorias;
        public List<string> Categorias
        {
            get { return _categorias; }
            set { SetProperty(ref _categorias, value); }
        }

        private Pregunta _nuevaPregunta;
        public Pregunta NuevaPregunta
        {
            get { return _nuevaPregunta; }
            set { SetProperty(ref _nuevaPregunta, value); }
        }
        private Pregunta _preguntaSeleccionada;
        public Pregunta PreguntaSeleccionada
        {
            get { return _preguntaSeleccionada; }
            set { SetProperty(ref _preguntaSeleccionada, value); }
        }
        
        private List<Pregunta> _preguntas;
        public List<Pregunta> Preguntas
        {
            get { return _preguntas; }
            set { SetProperty(ref _preguntas, value); }
        }
        public MainWindowVM()
        {
            _dificultades = Enum.GetNames(typeof(Pregunta.Dificultades)).ToList();
            _categorias = Enum.GetNames(typeof(Pregunta.Categorias)).ToList();
            NuevaPregunta = new Pregunta();
            _preguntas = new List<Pregunta>();
            _preguntas.Add(new Pregunta("Hola", "Prueba", AzureService.SubirImagen(@"C:\Users\alumno\Downloads"), Pregunta.Dificultades.Dificil, Pregunta.Categorias.Disney));
        }

        internal void AñadirPregunta()
        {
            if(!String.IsNullOrEmpty(NuevaPregunta.Texto) && !String.IsNullOrEmpty(NuevaPregunta.Respuesta) && !NuevaPregunta.Categoria.Equals(null))
            {
                NuevaPregunta.Imagen = AzureService.SubirImagen(NuevaPregunta.Imagen);
                _preguntas.Add(NuevaPregunta);
                LimpiaFormulario();
            }
        }

        public void LimpiaFormulario()
        {
            NuevaPregunta = new Pregunta();
        }

        public void AñadeImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
            if (openFileDialog.ShowDialog() == true)
                NuevaPregunta.Imagen = openFileDialog.FileName;
        }
    }
}
