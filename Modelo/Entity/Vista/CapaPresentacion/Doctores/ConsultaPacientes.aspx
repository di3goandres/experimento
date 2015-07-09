<%@ Page Title="" Language="C#" MasterPageFile="~/shared/Uniandes.master" AutoEventWireup="true" CodeFile="ConsultaPacientes.aspx.cs" Inherits="Doctores_ConsultaPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script src="../CustomJS/Doctores/DoctorConsultarPacientes.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center> 
       <h1 style="font-size:medium;">Consultar Paciente</h1>
         <input id="atras" value="Atras" style="width: 90px" type="button" />
           </center>
    <div id="Pacientes">
        <table class="table-filtro-busqueda">
            <tr>
                <td>
                    <label>Número de identificación</label></td>
                <td>
                    <input id="identificacion" type="text" placeholder="Número de Identificación" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input id="consultar" value="Consultar" style="width: 100px" /></td>
            </tr>
        </table>
        <br />
        <br />

        <center> 
          
        <table id="Datos">
        </table>
        <div id="pagerL">
        </div>
        </center>
    </div>
    <div id="HistorialEpisodios">
        <center> 
          <h1 style="font-size:medium;">Historial Episodios Usuarios</h1>
       
       
          
        <table id="DatosH">
        </table>
        <div id="pagerLH">
        </div>
        </center>
        <table class="table-filtro-busqueda">
            <tr>
                <td>
                   
            </tr>
        </table>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScripts" runat="Server">
</asp:Content>

