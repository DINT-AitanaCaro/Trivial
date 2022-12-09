using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Trivial.modelo;
using Trivial.servicios;

namespace Trivial
{
    class MainWindowVM : ObservableObject
    {
        private ObservableCollection<string> _dificultades;
        public ObservableCollection<string> Niveles
        {
            get { return _dificultades; }
            set { SetProperty(ref _dificultades, value); }
        }
        private ObservableCollection<string> _categorias;
        public ObservableCollection<string> Categorias
        {
            get { return _categorias; }
            set { SetProperty(ref _categorias, value); }
        }

        private Partida _partida;
        public Partida Partida
        {
            get { return _partida; }
            set { SetProperty(ref _partida, value); }
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

        private ObservableCollection<Pregunta> _preguntas;
        public ObservableCollection<Pregunta> Preguntas
        {
            get { return _preguntas; }
            set { SetProperty(ref _preguntas, value); }
        }

        private Pregunta _preguntaActual;
        public Pregunta PreguntaActual
        {
            get { return _preguntaActual; }
            set { SetProperty(ref _preguntaActual, value); }
        }

        private string _categoriaActual;
        public string Categoria
        {
            get { return _categoriaActual; }
            set { SetProperty(ref _categoriaActual, value); }
        }

        private string _pista;
        public string Pista
        {
            get { return _pista; }
            set { SetProperty(ref _pista, value); }
        }

        public MainWindowVM()
        {
            Niveles = new ObservableCollection<string> { "Fácil", "Media", "Difícil" };
            Categorias = CategoriasService.GetCategorias();
            NuevaPregunta = new Pregunta();
            Preguntas = new ObservableCollection<Pregunta>();
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
            if(!string.IsNullOrEmpty(ruta)) Preguntas = JsonService.CargaJson(ruta);
        }

        public void GuardaJson()
        {
            string ruta = DialogosService.DialogoGuardarFichero();
            if (!string.IsNullOrEmpty(ruta)) JsonService.GuardaJson(Preguntas, ruta);
            DialogosService.DialogoInformacion("Fichero JSON guardado correctamente.");
        }
        public void EliminarPregunta()
        {
            Preguntas.Remove(PreguntaSeleccionada);
            DialogosService.DialogoInformacion("Pregunta eliminada correctamente.");
        }

        public void NuevaPartida(string dificultad)
        {
            Partida = new Partida(dificultad);
            foreach (string c in Categorias)
            {
                List<Pregunta> preguntasValidas = Preguntas.Where(p => p.Categoria == c && p.Dificultad == dificultad).ToList();
                Random rnd = new Random();
                int num = rnd.Next(0,preguntasValidas.Count);
                Partida.Preguntas.Add(preguntasValidas[num]);
            }
            PreguntaActual = Partida.Preguntas[0];
            Categoria = PreguntaActual.Categoria;
        } 

        public void ValidaRespuesta()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, PreguntaActual.Respuesta.Length);
            foreach (char c in PreguntaActual.Respuesta)
            {
                if(rnd.Next(2) == 1)
                {
                    Pista += '*';
                }
                else
                {
                    Pista += c;
                }
            }
        }
    }
}
