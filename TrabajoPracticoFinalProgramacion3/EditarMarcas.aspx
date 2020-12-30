<%@ Page Title="" Language="C#" MasterPageFile="~/Placa.Master" AutoEventWireup="true" CodeBehind="EditarMarcas.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.EditarMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="texto">
        <h2 >Editar Marcas</h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
        <table style="margin-left: 20%">
            
            <tr>
               <td>Categoria:</td><td>
                <asp:DropDownList ID="ProductoCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ProductoCategoria_SelectedIndexChanged" ></asp:DropDownList>
                <br />
                </td>
            </tr>

            <tr>
               <td>Marcas:</td><td>
                <asp:DropDownList ID="ProductoMarca" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ProductoMarca_SelectedIndexChanged"></asp:DropDownList>
                <br />
                </td>
            </tr>

             <tr>
               <td>Nuevo Nombre de la marca:</td><td>
                 <asp:TextBox ID="txtNombre" runat="server" onkeypress="return soloLetras(event);"></asp:TextBox>
                 <br />
                </td>
            </tr>

            <tr>
                <td>Estado:</td>
                <td><asp:DropDownList ID="Estado" runat="server" AutoPostBack="true" ></asp:DropDownList>
                    <br />
                </td>
            </tr>

            <tr>
               <td>
                   &nbsp;</td><td><asp:Button ID="BotonGuardar" runat="server" Text="Guardar" OnClick="BotonGuardar_Click" />
                    <br />
                </td>
            </tr>
            <tr>
               <td>
                   &nbsp;</td><td><asp:Button ID="btnFin" runat="server" Text="Volver a Administrador" OnClick="btnFin_Click"/>
                    <br />
                </td>
            </tr>
           
        </table>
      </div>
</asp:Content>
