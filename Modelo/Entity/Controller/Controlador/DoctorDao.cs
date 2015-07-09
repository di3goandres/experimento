using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Uniandes.Entity;

namespace Uniandes.Controlador
{
    public class DoctorDao
    {
        public List<Doctor> obtenerDoctores(int paginaActual, int TamanioPagina, ref int TotalRegistros)
        {

            List<Doctor> retorno = new List<Doctor>();
            Conexion conn = new Conexion();
            SqlConnection cnn = conn.getSqlConnection();
            SqlCommand cmd = new SqlCommand("sp_consultar_doctores", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int);
            cmd.Parameters.Add("@PageNumber", SqlDbType.Int);

            cmd.Parameters["@PageSize"].Value = TamanioPagina;
            cmd.Parameters["@PageNumber"].Value = paginaActual;

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
                Doctor entidad = new Doctor();
                entidad.id_doctor = Convert.ToInt32(dr["id_doctor"].ToString());
                entidad.nombres_doctor = dr["nombres_doctor"].ToString();
                entidad.apellidos_doctor = dr["apellidos_doctor"].ToString();
                entidad.mail_doctor = dr["mail_doctor"].ToString();
                entidad.tipo_id = Convert.ToInt32(dr["tipo_id"].ToString());
                entidad.ident_doctor = dr["ident_doctor"].ToString();
             

                retorno.Add(entidad);
            }
            dr.Close();
            return retorno;

        }
     
        public List<Doctor> obtenerDoctoresIdentificaion(int paginaActual, int TamanioPagina, ref int TotalRegistros, string NumeroIdentificacion)
        {

            List<Doctor> retorno = new List<Doctor>();
            Conexion conn = new Conexion();
            SqlConnection cnn = conn.getSqlConnection();
            SqlCommand cmd = new SqlCommand("sp_consultar_doctores_identificacion", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int);
            cmd.Parameters.Add("@PageNumber", SqlDbType.Int);
            cmd.Parameters.Add("@Identificacion", SqlDbType.VarChar);
            cmd.Parameters["@PageSize"].Value = TamanioPagina;
            cmd.Parameters["@PageNumber"].Value = paginaActual;
            cmd.Parameters["@Identificacion"].Value = NumeroIdentificacion;
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
                Doctor entidad = new Doctor();
                entidad.id_doctor = Convert.ToInt32(dr["id_doctor"].ToString());
                entidad.nombres_doctor = dr["nombres_doctor"].ToString();
                entidad.apellidos_doctor = dr["apellidos_doctor"].ToString();
                entidad.mail_doctor = dr["mail_doctor"].ToString();
                entidad.tipo_id = Convert.ToInt32(dr["tipo_id"].ToString());
                entidad.ident_doctor = dr["ident_doctor"].ToString();


                retorno.Add(entidad);
            }
            dr.Close();
            return retorno;

        }

        public int asociarPacienteDoctor(int paciente, int doctor)
        {

            Conexion conn = new Conexion();
            SqlConnection cnn = conn.getSqlConnection();
            SqlCommand cmd = new SqlCommand("AsociarPacienteDoctor", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            #region(Crear parametros del procedimiento almacenado)
            cmd.Parameters.Add("@paciente", SqlDbType.Int);
            cmd.Parameters.Add("@doctor", SqlDbType.Int);
           


            #endregion

            #region(Pasar parametros del procedimiento almacenado)

            cmd.Parameters["@paciente"].Value /*   */= paciente;
            cmd.Parameters["@doctor"].Value/*      */= doctor;
           


            #endregion

            cmd.Connection.Open();
            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return i;

        
        }
    }
}
