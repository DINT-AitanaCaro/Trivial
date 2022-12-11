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
        private bool _partidaEnCurso;
        public bool PartidaEnCurso
        {
            get { return _partidaEnCurso; }
            set { SetProperty(ref _partidaEnCurso, value); }
        }

        public MainWindowVM()
        {
            Niveles = new ObservableCollection<string> { "Fácil", "Media", "Difícil" };
            Categorias = CategoriasService.GetCategorias();
            NuevaPregunta = new Pregunta();
            Preguntas = new ObservableCollection<Pregunta>();
            PreguntaActual = null;
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
            if (!string.IsNullOrEmpty(ruta))
            {
                ObservableCollection<Pregunta> preguntas = JsonService.CargaJson(ruta);
                if (preguntas == null) DialogosService.DialogoError("No se han cargado preguntas.");
                else Preguntas.Concat(preguntas);
            }
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
            if (dificultad != null)
            {
                List<Pregunta> preguntas = new List<Pregunta>();
                foreach (string c in Categorias)
                {
                    List<Pregunta> preguntasValidas = Preguntas.Where(p => p.Categoria == c && p.Dificultad == dificultad).ToList();
                    if (preguntasValidas.Count > 0)
                    {
                        Random rnd = new Random();
                        int num = rnd.Next(0, preguntasValidas.Count);
                        preguntas.Add(preguntasValidas[num]);
                    }
                }
                if (preguntas.Count == 0) DialogosService.DialogoError("No hay preguntas suficientes para crear una partida.");
                else
                {
                    Partida = new Partida(dificultad);
                    Partida.Preguntas = preguntas;
                    PartidaEnCurso = true;
                    SiguientePregunta();
                }
            }
            else
            {
                DialogosService.DialogoError("Selecciona una dificultad.");
            }
        }

        public bool ValidaRespuesta(string respuesta)
        {
            if (respuesta.ToLower() == PreguntaActual.Respuesta.ToLower())
            {

                //if(PartidaEnCurso)
                //{
                Pregunta acertada = Partida.Preguntas.First(p => p.Respuesta.ToLower() == respuesta.ToLower());
                MarcaCategoria(acertada.Categoria);
                Partida.Preguntas.Remove(acertada);

                SiguientePregunta();
                //}
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MarcaCategoria(string acertada)
        {
            switch (acertada)
            {
                case "Disney":
                    Partida.DisneyAdivinado = true;
                    break;
                case "Pixar":
                    Partida.PixarAdivinado = true;
                    break;
                case "Marvel":
                    Partida.MarvelAdivinado = true;
                    break;
                case "DC":
                    Partida.DcAdivinado = true;
                    break;
            }
        }
        public void SiguientePregunta()
        {
            if (Partida.Preguntas.Count == 0)
            {
                EndPartida();
            }
            else
            {
                PreguntaActual = PreguntaActual == null ? PreguntaActual = Partida.Preguntas[0] : Partida.Preguntas[Partida.Preguntas.IndexOf(PreguntaActual) + 1];
                Categoria = PreguntaActual.Categoria;
            }
        }
        public void EndPartida()
        {
            PartidaEnCurso = false;
            Partida = null;
            PreguntaActual = null;
            Categoria = null;
            DialogosService.DialogoInformacion("¡Enhorabuena!");
        }
    }
}
