using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivial.modelo;

namespace Trivial.servicios
{
    class JsonService
    {
        public static void GuardaJson(ObservableCollection<Pregunta> preguntas, string ruta)
        {
            string preguntasJson = JsonConvert.SerializeObject(preguntas);
            File.WriteAllText(ruta, preguntasJson);
        }

        public static ObservableCollection<Pregunta> CargaJson(string ruta)
        {
            return JsonConvert.DeserializeObject<ObservableCollection<Pregunta>>(File.ReadAllText(ruta));
        }
    }
}
