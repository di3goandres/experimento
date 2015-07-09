using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniandes.Entity
{
    public class Episodios
    {
        public int id_episodio { get; set; }
        public int id_paciente { get; set; }
        public int intensidad { get; set; }
        public string nombre_intensidad { get; set; }
        public DateTime fecha_episodio { get; set; }
        public int duracion { get; set; }


    }
}
