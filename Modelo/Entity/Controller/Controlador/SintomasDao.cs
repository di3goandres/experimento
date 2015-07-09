using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Uniandes.Entity;

namespace Uniandes.Controlador
{
    public class SintomasDao
    {
        public List<Sintomas> obtenerSintomas()
        {

            List<Sintomas> retorno = new List<Sintomas>();
            Conexion conn = new Conexion();
            SqlConnection cnn = conn.getSqlConnection();
            SqlCommand cmd = new SqlCommand("sp_obtener_sintomas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           
            while (dr.Read())
            {


                Sintomas entidad = new Sintomas();
                entidad.id_sintoma = Convert.ToInt32(dr["id_sintoma"].ToString());
                entidad.nombre_sintoma = dr["nombre_sintoma"].ToString();
                retorno.Add(entidad);
            }
            dr.Close();
            return retorno;

        }

        
    }
}
