<%@ Page Title="" Language="C#" MasterPageFile="~/Placa.Master" AutoEventWireup="true" CodeBehind="IngresoProductos.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="texto">
        <h2 >Nuevo Producto</h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
        <table style="margin-left: 20%">
            <tr>
                <td>Nombre: </td> <td><asp:TextBox ID="ProductoNombre"  onkeypress="return soloLetras(event);" runat="server" Width="180px"></asp:TextBox></td>
           </tr>

           <tr>
               <td>Descripcion: </td> <td><asp:TextBox ID="ProductoDescripcion" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox></td>
           </tr>

           <tr>
               <td>Stock: </td> <td><asp:TextBox ID="ProductoStock" runat="server"  onkeypress="return justNumbers(event);" Width="180px" TextMode="Number"></asp:TextBox></td>
           </tr>

           <tr>
               <td>Precio Unitario: </td> <td><asp:TextBox ID="ProductoPrecio"  onkeypress="return onKeyDecimal(this, event);" runat="server" Width="180px"></asp:TextBox></td>
           </tr>

           <tr>
               <td>Imagen: </td> <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
           </tr>

            <tr>
               <td>Categoria:</td><td>
                <asp:DropDownList ID="ProductoCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ProductoCategoria_SelectedIndexChanged1"></asp:DropDownList>
                </td>
            </tr>

            <tr>
               <td>Marcas:</td><td>
                <asp:DropDownList ID="ProductoMarca" runat="server" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>

            <tr>
               <td>
                   <asp:Button ID="BotonVisible" runat="server" Text="Agregar Marcas" OnClick="BotonVisible_Click" />
                </td><td><asp:Button ID="BotonGuardar" runat="server" Text="Guardar" OnClick="BotonGuardar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="Procesos Finalizados" runat="server" OnClick="Unnamed1_Click" /></td>
            </tr>
           
        </table>
      </div>

            <div id="barraCatMat">

        <asp:Label ID="Titulo" runat="server" Text="Nueva Marca para una categoria" Visible="false"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelAnuncio" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelCat" runat="server" Text="Categoria: " Visible="false"></asp:Label>
        &nbsp;<asp:DropDownList ID="ListaCatergoria" runat="server" Visible="false"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="LabelMarcas" runat="server" Text="Marcas: " Visible="false"></asp:Label>
        &nbsp;<asp:DropDownList ID="ListaMarcas" runat="server" Visible="false"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="LabelMar" runat="server" Text="Marca: " Visible="false"></asp:Label>
        &nbsp;<asp:TextBox ID="TextoMarca" runat="server" Width="90px" Visible="false"></asp:TextBox>
        <br />
        <br />

                   <asp:Button ID="Agregar" runat="server" Text="Aceptar" Visible="false" OnClick="Agregar_Click"  />
                <br />
        <br />
                   <asp:Button ID="hide" runat="server" Text="Acciones Finalizadas" Visible="false" OnClick="hide_Click"  />
    </div>

</asp:Content>
