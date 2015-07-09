using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uniandes.Entity;

namespace Uniandes.Controlador
{
    public class ArmarRespuestas
    {

        public Preguntas armarRespuestasSintomas()
        {
            try
            {
                List<Respuestas> respuestas = new List<Respuestas>();
                SintomasDao sd = new SintomasDao();
                var pregunta = sd.obtenerSintomas();
                Preguntas preg = new Preguntas();
                preg.NUMERO_PREGUNTA=3;
                preg.PREGUNTA = "Sintomas";


                preg.TIPO_RESPUESTA_ESPERADA ="checkbox";
              
                foreach (var pre in pregunta)
                {
                    string tipoDato = "checkbox";





                    respuestas.Add(new Respuestas()
                    {
                        ID_SELECCION_PREGUNTA = pre.id_sintoma,
                        ID_HTML = pre.id_sintoma.ToString(),//+ data.NUMERO_PREGUNTA.ToString() + pre.ID_PREGUNTA_ENCUESTA.ToString() + tipoDato,
                        NAME = "Sintomas" + "_" + tipoDato,
                        RESPUESTA = pre.nombre_sintoma,
                        TIPO_DATO = tipoDato,
                        VALUE = ""//data.ID_SELECCION_PREGUNTAS_ENCUESTA.ToString(),//data.RESPUESTA,


                    });
                }
                // ya tengo las respuesta en el listado ahora se le agrega a la entidad

                preg.respuestas_pregunta = respuestas;
                return preg;



            }
            catch (Exception exc) { throw exc; }

        }


        public Preguntas armarRespuestasCatalizadores()
        {
            try
            {
                List<Respuestas> respuestas = new List<Respuestas>();
                CatalizadoresDao sd = new CatalizadoresDao();
                var pregunta = sd.obtenerCatalizadores();
                Preguntas preg = new Preguntas();
                preg.NUMERO_PREGUNTA = 4;
                preg.PREGUNTA = "Posibles factores desencadenantes";


                preg.TIPO_RESPUESTA_ESPERADA = "checkbox";

                foreach (var pre in pregunta)
                {
                    string tipoDato = "checkbox";





                    respuestas.Add(new Respuestas()
                    {
                        ID_SELECCION_PREGUNTA = pre.id_catalizador,
                        ID_HTML = pre.id_catalizador.ToString(),//+ data.NUMERO_PREGUNTA.ToString() + pre.ID_PREGUNTA_ENCUESTA.ToString() + tipoDato,
                        NAME = "Catalizadores" + "_" + tipoDato,
                        RESPUESTA = pre.nombre_catalizador,
                        TIPO_DATO = tipoDato,
                        VALUE = ""//data.ID_SELECCION_PREGUNTAS_ENCUESTA.ToString(),//data.RESPUESTA,


                    });
                }
                // ya tengo las respuesta en el listado ahora se le agrega a la entidad

                preg.respuestas_pregunta = respuestas;
                return preg;



            }
            catch (Exception exc) { throw exc; }

        }


        public List<Preguntas> RetornaPreguntas() {

            List<Preguntas> retorno = new List<Preguntas>();
            var uno = armarRespuestasSintomas();
            retorno.Add(uno);
            var dos = armarRespuestasCatalizadores();
            retorno.Add(dos);
            return retorno;
        
        }
    }


}
