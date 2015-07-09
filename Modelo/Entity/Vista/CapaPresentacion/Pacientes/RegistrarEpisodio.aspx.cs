using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uniandes.Utilidades;
using Uniandes.Controlador;

public partial class Pacientes_RegistrarEpisodio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static object TraerInformacionInicial()
    {
        try
        {
            //var datos = new GestorPreguntaEncuesta();
            var resultado = new ArmarRespuestas().RetornaPreguntas();
            //var resultadopregunta_26 = datos.ConsultarPreguntasConrespuestasParaArmar(24);
            return new
            {
                Ok = "OK",
                aniofechaIngresoMaxima = (DateTime.Now.AddYears(15).Year), // se le restan los dias del mes para que de el ultimo del mes anterior
                mesfechaIngresoMaxima = DateTime.Now.AddYears(15).Month - 1,  // por que el datepicker de jquery empieza en cero
                diafechaIngresoMaxima = DateTime.Now.Day,
                aniofechaIngresoMinima = (DateTime.Now.AddYears(-1)).Year, // se le restan los dias del mes para que de el ultimo del mes anterior
                mesfechaIngresoMinima = (DateTime.Now.AddYears(-1)).Month - 1,  // por que el datepicker de jquery empieza en cero
                diafechaIngresoMinima = (DateTime.Now.AddDays(-1)).Day,
                preguntas = resultado,


            };



        }
        catch (EndSessionException end)
        {
            AppLog.Write("Su session ha finalizado", AppLog.LogMessageType.Info, end, "AcdivocaLog");
            return new { OK = "Su session ha finalizado" };
        }
        catch (Exception ex)
        {
            AppLog.Write(" Error obteniendo la informacion Inicial. ", AppLog.LogMessageType.Error, ex, "AcdivocaLog");

            return new
            {
                Ok = "Error Consultando información inicial.",
                MsgError = ex.Message + ex.StackTrace
            };
        }
    }
}