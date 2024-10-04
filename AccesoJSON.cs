using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace EspacioCadeteria
{
    public class AccesoJSON : AccesoADatos
    {
        public override Cadeteria Cargar(string archivoJsonCadeteria, string archivoJsonCadete)
        {
            // Cargar datos de la cadetería desde JSON
            string cadeteriaJson = File.ReadAllText(archivoJsonCadeteria);
            var datosCadeteria = JsonSerializer.Deserialize<Dictionary<string, string>>(cadeteriaJson);
            Cadeteria cadeteria = new Cadeteria(datosCadeteria["Nombre"], datosCadeteria["Telefono"]);

            // Cargar datos de los cadetes desde JSON
            string cadetesJson = File.ReadAllText(archivoJsonCadete);
            List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(cadetesJson);

            // Asignar cadetes a la cadetería
            foreach (Cadete cadete in listaCadetes)
            {
                cadeteria.AgregarCadete(cadete);
            }

            return cadeteria;
        }
    }
}
