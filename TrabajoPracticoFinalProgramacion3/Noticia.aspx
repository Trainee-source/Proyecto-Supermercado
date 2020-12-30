<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Noticia.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.Noticia" %>

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
                <div class="modal-text">
                    
                    <asp:Label ID="Label1" runat="server" Text="Se han realizado las modificaciones existosamente."></asp:Label>
                    </br>
                    </br>
                   
                    <asp:Button ID="btnRedirect" runat="server" Text="Aceptar" OnClick="btnRedirect_Click" />
                   
                </br>
            </div>
        </div>
             </div>
    </form>
</body>
</html>

