using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivial.modelo;

namespace Trivial.servicios
{
    class JsonService
    {
        public static void GuardaJson(List<Pregunta> preguntas, string ruta)
        {
            string preguntasJson = JsonConvert.SerializeObject(preguntas);
            File.WriteAllText(ruta, preguntasJson);
        }

        public static List<Pregunta> CargaJson(string ruta)
        {
            return JsonConvert.DeserializeObject<List<Pregunta>>(File.ReadAllText(ruta));
        }
    }
}
