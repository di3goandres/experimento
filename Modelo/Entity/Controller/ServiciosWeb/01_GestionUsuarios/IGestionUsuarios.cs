using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Uniandes.Entity;

namespace Uniandes.GestionUsuarios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGestionUsuarios
    {

        [OperationContract]
        List<Paciente> obtenerPacientes(int paginaActual, int TamanioPagina, ref int TotalRegistros);

        [OperationContract]
        List<Paciente> obtenerPacientes(int paginaActual, int TamanioPagina, ref int TotalRegistros, string NumeroIdentificacion);

        [OperationContract]
        int registrarPacienteNuevo(Paciente pacienteNuevo);

        // TODO: Add your service operations here
    }



}
