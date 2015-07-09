using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Uniandes.Entity;

namespace Uniandes.Controlador
{
    public class EpisodiosDao
    {
        public List<Episodios> obtenerEpisodiosPacientes(int paginaActual, int TamanioPagina, ref int TotalRegistros, int idpaciente)
        {

            List<Episodios> retorno = new List<Episodios>();
            Conexion conn = new Conexion();
            SqlConnection cnn = conn.getSqlConnection();
            SqlCommand cmd = new SqlCommand("sp_consulta_episodios_por_paciente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int);
            cmd.Parameters.Add("@PageNumber", SqlDbType.Int);
            cmd.Parameters.Add("@idpaciente", SqlDbType.Int);
            cmd.Parameters["@PageSize"].Value = TamanioPagina;
            cmd.Parameters["@PageNumber"].Value = paginaActual;
            cmd.Parameters["@idpaciente"].Value = idpaciente;
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            bool primera = true;
            while (dr.Read())
            {
                if (primera)
                {
                    TotalRegistros = Convert.ToInt32(dr["TotalRows"].ToString());
                    primera = false;
                }

                Episodios entidad = new Episodios();
                entidad.id_episodio = Convert.ToInt32(dr["id_episodio"].ToString());
                entidad.id_paciente = Convert.ToInt32(dr["id_paciente"].ToString());
                entidad.duracion = Convert.ToInt32(dr["duracion"].ToString());
                entidad.nombre_intensidad = dr["nombre_intensidad"].ToString();
                entidad.fecha_episodio = Convert.ToDateTime(dr["fecha_episodio"].ToString());
              

                retorno.Add(entidad);
            }
            dr.Close();
            return retorno;

        }
        public List<Episodios> obtenerEpisodiosPacientes(int paginaActual, int TamanioPagina, ref int TotalRegistros, string idpaciente)
        {

            List<Episodios> retorno = new List<Episodios>();
            Conexion conn = new Conexion();
            SqlConnection cnn = conn.getSqlConnection();
            SqlCommand cmd = new SqlCommand("sp_consulta_episodios_por_paciente_userid", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int);
            cmd.Parameters.Add("@PageNumber", SqlDbType.Int);
            cmd.Parameters.Add("@idpaciente", SqlDbType.VarChar);
            cmd.Parameters["@PageSize"].Value = TamanioPagina;
            cmd.Parameters["@PageNumber"].Value = paginaActual;
            cmd.Parameters["@idpaciente"].Value = idpaciente;
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            bool primera = true;
            while (dr.Read())
            {
                if (primera)
                {
                    TotalRegistros = Convert.ToInt32(dr["TotalRows"].ToString());
                    primera = false;
                }

                Episodios entidad = new Episodios();
                entidad.id_episodio = Convert.ToInt32(dr["id_episodio"].ToString());
                entidad.id_paciente = Convert.ToInt32(dr["id_paciente"].ToString());
                entidad.duracion = Convert.ToInt32(dr["duracion"].ToString());
                entidad.nombre_intensidad = dr["nombre_intensidad"].ToString();
                entidad.fecha_episodio = Convert.ToDateTime(dr["fecha_episodio"].ToString());


                retorno.Add(entidad);
            }
            dr.Close();
            return retorno;

        }
     
    }
}
