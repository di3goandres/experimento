using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uniandes.AccesoDatos.Menu;
using Uniandes.Controlador;
using Uniandes.Entity;
using Uniandes.GestionUsuarios;
using Uniandes.Utilidades;

public partial class Doctores_ConsultaPacientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static GridData GetGridDataWithPaging(
        string colName, string sortOrder, int numPage, int numRows, string searchField, string searchString, string searchOper, bool isSearch, string NumeroIdentificacion)
    {
        GridData gridData = new GridData();
        gridData = _getListListConPaginacion(numPage, numRows, numPage, isSearch, searchField, searchString, searchOper, NumeroIdentificacion);
        return gridData;
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static GridData GetGridDataWithPagingHistorial(
        string colName, string sortOrder, int numPage, int numRows, string searchField, string searchString, string searchOper, bool isSearch, int Paciented)
    {
        GridData gridData = new GridData();
        gridData = _getListListConPaginacionHistorial(numPage, numRows, numPage, isSearch, searchField, searchString, searchOper, Paciented);
        return gridData;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static object EditarAgregar(
       string NombrePerfil, string Descripcion, string Prefijo,
        int ID,
        bool EsEditar)
    {

        try
        {

            DaoPerfil perfilDao = new DaoPerfil();

            GestionRoles gestRoles = new GestionRoles();

            //
            if (!EsEditar)
            {
                #region ("AGREGAR")


                bool resultado = false;
                #region (verificar si existe el rol por el prefijo)
                var existe = gestRoles.RoleExists(Prefijo);
                if (existe)
                {

                    return new
                    {
                        Ok = "Error",
                        mensaje = "El perfil ya existe en nuestra base de datos, se identifica por el PREFIJO"

                    };
                }

                #endregion
                resultado = perfilDao.InsertPerfil(NombrePerfil, Descripcion, Prefijo);
                #region ("Resultado agregar")
                if (resultado)
                {
                    gestRoles.CreateRole(Prefijo);

                    return new
                    {
                        Ok = "OK",
                        mensaje = "Se ha agregado el registro Correctamente"

                    };
                }
                else
                {
                    return new
                    {
                        Ok = "error",
                        mensaje = "No se ha podido registrar el usuario."

                    };
                }
                #endregion
            }
            else
            {

                var resultado = perfilDao.ActualizarPerfil(NombrePerfil, Descripcion, ID);
                if (resultado)
                {

                    return new
                    {
                        Ok = "OK",
                        mensaje = "Se ha Actualizado el registro Correctamente"

                    };
                }
                else
                {
                    return new
                    {
                        Ok = "error",
                        mensaje = "No se ha podido Actualizar el registro ."

                    };
                }
            }


                #endregion




        }
        catch (Exception ex)
        {

            return new
            {
                Ok = "Error",
                mensaje = "ha Ocurrido un error inesperado: " + ex.ToString()

            };

        }
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static object Eliminar(
        String ID
        )
    {

        try
        {

            DaoPerfil perfilDao = new DaoPerfil();
            GestionUsuario gestor = new GestionUsuario();


            bool resultado = false;

            resultado = gestor.DeleteUser(ID);
            GestionRoles gestRoles = new GestionRoles();
            #region ("Resultado agregar")
            if (resultado)
            {


                return new
                {
                    OK = "OK",
                    mensaje = "Se ha Eliminado el registro Correctamente"

                };
            }
            else
            {
                return new
                {
                    OK = "error",
                    mensaje = "No se ha podido eliminar el usuario."

                };
            }
            #endregion



        }
        catch (Exception ex)
        {

            return new
            {
                OK = "Error",
                mensaje = "ha Ocurrido un error inesperado: " + ex.ToString()

            };

        }
    }

   
    private static GridData _getListListConPaginacion(int pageIndex, int pageSize, int pageCount, bool isSearch, string searchField, string searchString, string searchOper, string NumeroIdentificacion)
    {
        try
        {
            int totalRecords = 0;

            DaoPerfil perfilDao = new DaoPerfil();

            List<Paciente> resultado = new List<Paciente>();
            PacienteDao pd = new PacienteDao();
            if (string.IsNullOrWhiteSpace(NumeroIdentificacion))
            {
                resultado = pd.obtenerPacientes(pageIndex - 1, pageSize, ref totalRecords); ;
            }
            else
            {
                resultado = pd.obtenerPacientes(pageIndex - 1, pageSize, ref totalRecords, NumeroIdentificacion);


            }
          
            List<GridRow> listProcesos = new List<GridRow>();

            #region ("TOTAL==0")
            if (totalRecords == 0)
            {
                return new GridData
                {
                    page = pageIndex,
                    total = (int)Math.Ceiling((double)totalRecords / (double)pageSize),
                    records = totalRecords,
                    rows = new List<GridRow>(),
                    userMessage = "Se han cargado los datos con éxito.",
                    logMessage = "Carga satisfactoria...",
                    status = Status.OK
                };
            }
            #endregion
            else
            {
                //pageIndex,
                //pageSize, ref totalRecords, estado, banda, UID, plan, cliente);
                int id = 0;

                //foreach (var user in resultado)
                //{
                //    userList.Add(user);
                //}
                foreach (var proceso in resultado)
                {
                    id++;
                    listProcesos.Add(


      new GridRow()
      {
          id = proceso.id_paciente.ToString(),
          cell = new List<object>(){
                        proceso.id_paciente.ToString(),
                        proceso.nombres_paciente.ToString().ToUpper()+ " " + proceso.apellidos_paciente.ToString().ToUpper(),
                        proceso.ident_paciente,
                        proceso.mail_paciente,
                        proceso.movil_paciente,
                        }
      });
                }

            }

            /// Con la información de los procesos y de la consulta se ensambla el objeto GridData de respuesta.
            /// 
            return new GridData
            {
                page = pageIndex,
                total = (int)Math.Ceiling((double)totalRecords / (double)pageSize),
                records = totalRecords,
                rows = listProcesos,
                userMessage = "Se han cargado los datos con éxito.",
                logMessage = "Carga satisfactoria...",
                status = Status.OK
            };

        }
        catch (Exception ex)
        {
            AppLog.Write(" Error consultando la informacion de Cities ", AppLog.LogMessageType.Error, ex, "IbMallsLog");

            return new GridData
            {
                page = pageIndex,
                total = default(int),
                records = default(int),
                rows = new List<GridRow>(),
                userMessage = "Se han cargado los datos con éxito.",
                logMessage = "Carga satisfactoria...",
                status = Status.OK_WITH_MESSAGES
            };
        }
    }

    private static GridData _getListListConPaginacionHistorial(int pageIndex, int pageSize, int pageCount, bool isSearch, string searchField, string searchString, string searchOper, int Paciented)
    {
        try
        {
            int totalRecords = 0;

            DaoPerfil perfilDao = new DaoPerfil();

            List<Episodios> resultado = new List<Episodios>();
            EpisodiosDao pd = new EpisodiosDao();

            resultado = pd.obtenerEpisodiosPacientes(pageIndex - 1, pageSize, ref totalRecords, Paciented); ;
           

            List<GridRow> listProcesos = new List<GridRow>();

            #region ("TOTAL==0")
            if (totalRecords == 0)
            {
                return new GridData
                {
                    page = pageIndex,
                    total = (int)Math.Ceiling((double)totalRecords / (double)pageSize),
                    records = totalRecords,
                    rows = new List<GridRow>(),
                    userMessage = "Se han cargado los datos con éxito.",
                    logMessage = "Carga satisfactoria...",
                    status = Status.OK
                };
            }
            #endregion
            else
            {
                //pageIndex,
                //pageSize, ref totalRecords, estado, banda, UID, plan, cliente);
                int id = 0;

                //foreach (var user in resultado)
                //{
                //    userList.Add(user);
                //}
                foreach (var proceso in resultado)
                {
                    id++;
                    listProcesos.Add(


      new GridRow()
      {
          id = proceso.id_episodio.ToString(),
          cell = new List<object>(){
                        proceso.id_episodio.ToString(),
                        proceso.nombre_intensidad.ToString().ToUpper(),
                        proceso.fecha_episodio.ToString("yyyy/MM/dd HH:mm"),
                        proceso.duracion,
                       
                        }
      });
                }

            }

            /// Con la información de los procesos y de la consulta se ensambla el objeto GridData de respuesta.
            /// 
            return new GridData
            {
                page = pageIndex,
                total = (int)Math.Ceiling((double)totalRecords / (double)pageSize),
                records = totalRecords,
                rows = listProcesos,
                userMessage = "Se han cargado los datos con éxito.",
                logMessage = "Carga satisfactoria...",
                status = Status.OK
            };

        }
        catch (Exception ex)
        {
            AppLog.Write(" Error consultando la informacion de Cities ", AppLog.LogMessageType.Error, ex, "IbMallsLog");

            return new GridData
            {
                page = pageIndex,
                total = default(int),
                records = default(int),
                rows = new List<GridRow>(),
                userMessage = "Se han cargado los datos con éxito.",
                logMessage = "Carga satisfactoria...",
                status = Status.OK_WITH_MESSAGES
            };
        }
    }


}