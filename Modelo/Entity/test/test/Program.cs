using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uniandes.Controlador;
using Uniandes.Entity;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var datini = DateTime.Now;

           

            crearUsuario();
            ObtenerPacientes();


            ObtenerPacientesIdentificacion();

            var datefin = DateTime.Now - datini;

            var total = datefin.Milliseconds;
        }

        private static void crearUsuario()
        {
            Paciente newP = new Paciente();
            newP.nombres_paciente = "fernando";
            newP.apellidos_paciente = "Pruebas Calima";
            newP.ident_paciente = "10889";
            newP.tipo_id = 1;
            newP.telefono_paciente = "318788545";
            newP.movil_paciente = "318788545";
            newP.direccion_paciente = "av siempre viva calle falsa 124";
            newP.genero_paciente = 2;

            newP.fecha_nacimiento = new DateTime(1987, 03, 6);
            PacienteDao pd = new PacienteDao();
            pd.registrarPacienteNuevo(newP);
        }

        private static void ObtenerPacientesIdentificacion()
        {
            PacienteDao pd = new PacienteDao();
            int totalregistros = 0;
            var re = pd.obtenerPacientes(0, 10, ref totalregistros,"1077845378");
        }

        private static void ObtenerPacientes()
        {
           
            PacienteDao pd = new PacienteDao();
            int totalregistros = 0;
            var re = pd.obtenerPacientes(0, 10, ref totalregistros);

           
        }
    }
}
