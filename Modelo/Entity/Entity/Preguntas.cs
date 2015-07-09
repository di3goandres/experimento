using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniandes.Entity
{
    public class Preguntas
    {

        public int ID_PREGUNTA_ENCUESTA { get; set; }
      
        public int NUMERO_PREGUNTA { get; set; }
        public string PREGUNTA { get; set; }
        public List<Respuestas> respuestas_pregunta { get; set; }
        public string TIPO_RESPUESTA_ESPERADA { get; set; }
    }
}
