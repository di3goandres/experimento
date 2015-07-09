using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniandes.Entity
{
    public class Respuestas
    {
        public Int64 ID_SELECCION_PREGUNTA { get; set; }

        /// <summary>
        /// id con el cual se identificara en el html
        /// </summary>
        public string ID_HTML { get; set; }

        /// <summary>
        /// nombre para mostrar en el html
        /// </summary>
        public string RESPUESTA { get; set; }

        /// <summary>
        /// tipo de dato para generar
        /// </summary>
        public string TIPO_DATO { get; set; }

        /// <summary>
        /// si son radio button colocarle el name
        /// el cual solo dejara seleccionar un solo dato
        /// </summary>
        public string NAME { get; set; }

        public string VALUE { get; set; }
    }
}
