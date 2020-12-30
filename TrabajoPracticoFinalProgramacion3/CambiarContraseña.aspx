<%@ Page Title="" Language="C#" MasterPageFile="~/Placa.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos%20CSS/Estilo%20Administrador.css" rel="stylesheet" runat="server"/>
        <div class="ventanaAdmin">
            <div class="solapasAdmin">
                <asp:Label Text="Cambio de Contraseña" runat="server" class="labels"/>
                <br />
                <asp:Label Text="Ingrese su DNI: " runat="server" class="labels"/> <asp:TextBox id="boxDNI" runat="server" />
                <br />
                <br />
                <asp:Label Text="Ingrese su Email" runat="server" class="labels"/> <asp:TextBox id="boxEmail" runat="server" />
                <br />
                <br />
                <asp:Label Text="Ingrese su nueva contraseña" runat="server" class="labels"/> <asp:TextBox id="boxPass" runat="server" />
                <br />
                <br />
                <asp:Label Text="Ingrese Nuevamente su contraseña" runat="server" class="labels"/> <asp:TextBox  id="boxPass2" runat="server" />
                <br />
                <br />
                <asp:Label ID="lblAviso" Text="" runat="server" ForeColor="Red" class="labels"/>
                <br />
                <asp:Button Text="Aceptar" runat="server" OnClick="Aceptar_Click" />
            </div>
        </div>

</asp:Content>
