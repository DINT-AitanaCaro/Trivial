using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Trivial.servicios
{
    class DialogosService
    {
        public static string DialogoAbrirFichero(string extensiones)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"Files ({extensiones})|{extensiones}|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;
            else return null;
        }

        public static string DialogoGuardarFichero()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                return saveFileDialog.FileName;
            else return null;
        }

        public static void DialogoError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void DialogoInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Acción realizada", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
