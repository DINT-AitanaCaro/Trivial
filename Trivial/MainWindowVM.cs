using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using Newtonsoft.Json;
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
            Niveles = new List<string> { "Fácil", "Media", "Difícil" };
            Categorias = new List<string> { "Disney", "Pixar", "Marvel", "DC" };
            NuevaPregunta = new Pregunta();
            Preguntas = new List<Pregunta>();
            //_preguntas.Add(new Pregunta("En la película Aladdin, ¿cómo se llama el loro?", "Prueba", AzureService.SubirImagen(@"C:\Users\aitan\Downloads\iago.jpg"), Pregunta.Dificultades.Difícil, Pregunta.Categorias.Disney));
        }

        public void AñadirPregunta()
        {
            NuevaPregunta.Imagen = AzureService.SubirImagen(NuevaPregunta.Imagen);
            Preguntas.Add(NuevaPregunta);
            LimpiaFormulario();
        }

        public void LimpiaFormulario()
        {
            NuevaPregunta = new Pregunta();
        }

        public void AñadeImagen()
        {
            NuevaPregunta.Imagen = DialogosService.DialogoAbrirFichero("*.png;*.jpeg;*.jpg");
        }

        public void CargaJson()
        {
            string ruta = DialogosService.DialogoAbrirFichero("*.json");
            if(!String.IsNullOrEmpty(ruta)) Preguntas = JsonService.CargaJson(ruta);
        }

        public void GuardaJson()
        {
            string ruta = DialogosService.DialogoGuardarFichero();
            if (!String.IsNullOrEmpty(ruta)) JsonService.GuardaJson(Preguntas, ruta);
        }
        public void EliminarPregunta()
        {
            Preguntas.Remove(PreguntaSeleccionada);
        }
    }
}
