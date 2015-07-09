using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Uniandes.Controlador;

namespace Uniandes.GestionUsuarios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GestionUsuarios : IGestionUsuarios
    {
        #region ("Dao Pacientes")
        public List<Entity.Paciente> obtenerPacientes(int paginaActual, int TamanioPagina, ref int TotalRegistros)
        {
            PacienteDao pd = new PacienteDao();

            return pd.obtenerPacientes(paginaActual, TamanioPagina, ref TotalRegistros);

        }

        public List<Entity.Paciente> obtenerPacientes(int paginaActual, int TamanioPagina, ref int TotalRegistros, string NumeroIdentificacion)
        {
            PacienteDao pd = new PacienteDao();

            return pd.obtenerPacientes(paginaActual, TamanioPagina, ref TotalRegistros, NumeroIdentificacion);
        }

        public int registrarPacienteNuevo(Entity.Paciente pacienteNuevo)
        {
            PacienteDao pd = new PacienteDao();
            return pd.registrarPacienteNuevo(pacienteNuevo);

        }
        #endregion

    }
}
