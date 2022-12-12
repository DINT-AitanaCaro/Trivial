using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trivial
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowVM();
            DataContext = vm;
        }

        private void examinarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AñadeImagen();
        }

        private void limpiarFormButton_Click(object sender, RoutedEventArgs e)
        {
            vm.LimpiaFormulario();
        }

        private void añadirPreguntaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AñadirPregunta();
        }

        private void cargaJSONButton_Click(object sender, RoutedEventArgs e)
        {
            vm.CargaJson();
        }

        private void guardaJSONButton_Click(object sender, RoutedEventArgs e)
        {
            vm.GuardaJson();
        }

        private void eliminarPreguntaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarPregunta();
        }

        private void nuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            string dificultad = (dificultadPartidaComboBox.SelectedItem == null) ? null : dificultadPartidaComboBox.SelectedItem.ToString();
            vm.NuevaPartida(dificultad);

        }

        private void validarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.ValidaRespuesta();

        }

        private void limpiarSeleccionPreguntaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.LimpiarSeleccion();
            editarExpander.IsExpanded = false;
        }

        private void ordenarCategoriaCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            vm.OrdenarPorCategoria();
        }

        private void ordenarCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            vm.PreguntasOrdenAnterior((bool)ordenarCategoriaCheckbox.IsChecked, (bool)ordenarDificultadCheckbox.IsChecked);
        }

        private void ordenarDificultadCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            vm.OrdenarPorDificultad();
        }
    }
}
