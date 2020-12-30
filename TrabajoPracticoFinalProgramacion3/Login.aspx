<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Estilos%20CSS/popUp.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 92px;
            height: 89px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg-modal">
            <div class="modal-content">
                <img src="ImagenesWeb/LogoWeb.png" alt="Alternate Text" class="auto-style1" />
                <div class="close">
                    <asp:Button Text="+" runat="server" BackColor="White" BorderColor="White" Font-Bold="True" Font-Size="Medium" ForeColor="Black" OnClick="Unnamed1_Click" /></div>
                <div class="modal-text">
                    
                    Su Email:
                    <asp:TextBox id="UsuarioEmail" runat="server" Width="180px" margin-color="black" BorderColor="Gray" ForeColor="Black"  ></asp:TextBox>
                    <br />
                    <br />
                    Su Contraseña:
                    <asp:TextBox id="UsuarioContraseña" runat="server" Width="180px" BorderColor="Gray" ForeColor="Black" TextMode="Password"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button Text="Aceptar" runat="server" id="botonAceptar" OnClick="botonAceptar_Click"/>
                    <br />
                    <br />
                    <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:LinkButton ID="Registrarse" runat="server" OnClick="Registrarse_Click"> Nuevo Usuario</asp:LinkButton>

                    <br />

                    <br />
                    <asp:LinkButton ID="btnNuevaContraseña" Text="text" runat="server" OnClick="btnNuevaContraseña_Click" >Nueva Contraseña</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
