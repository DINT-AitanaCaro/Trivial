using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivial.servicios
{
    class CategoriasService
    {
        private static ObservableCollection<string> _categorias = new ObservableCollection<string> { "Disney", "Pixar", "Marvel", "DC" };

        public static ObservableCollection<string> Categorias
        {
            get { return _categorias; }
            set { _categorias = value; }
        }

        public static ObservableCollection<string> GetCategorias()
        {
            return Categorias;
        }

        public static void AñadirCategoria(string categoria)
        {
            Categorias.Add(categoria);
        }
    }
}
