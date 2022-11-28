using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trivial.modelo;

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
        public MainWindowVM()
        {
            _dificultades = Enum.GetNames(typeof(Pregunta.Dificultades)).ToList();
            _categorias = Enum.GetNames(typeof(Pregunta.Categorias)).ToList();
            NuevaPregunta = new Pregunta();
            NuevaPregunta.Dificultad = Pregunta.Dificultades.Medio;
        }

        public void LimpiaFormulario()
        {
            NuevaPregunta = new Pregunta();
        }

        public void AñadeImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                NuevaPregunta.Imagen = openFileDialog.FileName;
        }
    }
}
