<%@ Page Title="" Language="C#" MasterPageFile="~/Placa.Master" AutoEventWireup="true" CodeBehind="IngresoUsuario.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.IngresoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="texto">
        <asp:Label ID="lblPagina" runat="server" Text="Nuevo Usuario"></asp:Label>
        <table style="margin-left: 20%">
            <tr>
                <td style="width: 200px;">
                    <asp:Label ID="lblDni" runat="server" Text="Ingrese su DNI"></asp:Label>
                </td> <td><asp:TextBox ID="UsuarioDni" runat="server" onkeypress="return justNumbers(event);" Width="180px" ></asp:TextBox></td>
           </tr>

           <tr>
                <td style="width: 200px;">Ingrese su Nombre: </td> <td><asp:TextBox ID="UsuarioNombre" onkeypress="return soloLetras(event);" runat="server" Width="180px" ></asp:TextBox></td>
           </tr>

           <tr>
                <td style="width: 200px;">Ingrese su Apellidos: </td> <td><asp:TextBox ID="UsuarioApellidos" onkeypress="return soloLetras(event);" runat="server" Width="180px" ></asp:TextBox></td>
           </tr>

           <tr>
                <td style="width: 200px;">Ingrese su Email: </td> <td><asp:TextBox ID="UsuarioEmail" runat="server" Width="180px" TextMode="Email" ></asp:TextBox></td>
           </tr>

           <tr>
                <td style="width: 200px;"> 
                    <asp:Label ID="lblContraseña1" runat="server" Text="Ingrese su Contraseña:"></asp:Label>
                </td> <td><asp:TextBox ID="UsuarioContraseña" runat="server" Width="180px" TextMode="Password" ></asp:TextBox></td>
           </tr>

            <tr>
                <td style="width: 200px;"> 
                    <asp:Label ID="lblContraseña2" runat="server" Text="Repita La Contraseña:"></asp:Label>
                </td> <td><asp:TextBox ID="UsuarioContraseña2" runat="server" Width="180px" TextMode="Password"></asp:TextBox></td>
           </tr>
           <tr>
                <td style="width: 200px;"></td> <td><asp:Button ID="BotonGuardar" runat="server" Text="Aceptar" OnClick="BotonGuardar_Click" /></td>
           </tr>
            
        </table>
        
        
        
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        
        
        
    </div>
</asp:Content>
