using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Uniandes.Entity;

namespace Uniandes.Controlador
{
    public class CatalizadoresDao
    {
        public List<Catalizadores> obtenerCatalizadores()
        {

            List<Catalizadores> retorno = new List<Catalizadores>();
            Conexion conn = new Conexion();
            SqlConnection cnn = conn.getSqlConnection();
            SqlCommand cmd = new SqlCommand("sp_obtener_catalizadores", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {


                Catalizadores entidad = new Catalizadores();
                entidad.id_catalizador = Convert.ToInt32(dr["id_catalizador"].ToString());
                entidad.nombre_catalizador = dr["nombre_catalizador"].ToString();
                retorno.Add(entidad);
            }
            dr.Close();
            return retorno;

        }

    }
}
