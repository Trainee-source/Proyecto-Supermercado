<%@ Page Title="" Language="C#" MasterPageFile="~/Placa.Master" AutoEventWireup="true" CodeBehind="EditarProducto.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="texto">
        <h2 >Editar Producto</h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
        <table style="margin-left: 20%">
            <tr>
                <td>Nombre: </td> <td><asp:TextBox ID="ProductoNombre" onkeypress="return soloLetras(event);" runat="server" Width="180px"></asp:TextBox></td>
           </tr>

           <tr>
               <td>Descripcion: </td> <td><asp:TextBox ID="ProductoDescripcion" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox></td>
           </tr>

           <tr>
               <td>Stock: </td> <td><asp:TextBox ID="ProductoStock" runat="server" onkeypress="return justNumbers(event);" Width="180px" TextMode="Number"></asp:TextBox></td>
           </tr>

           <tr>
               <td>Precio Unitario: </td> <td><asp:TextBox ID="ProductoPrecio" runat="server" onkeypress="return onKeyDecimal(this, event);" Width="180px"></asp:TextBox></td>
           </tr>

           <tr>
               <td>Imagen: </td> <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
           </tr>

            <tr>
               <td>Categoria:</td><td>
                <asp:DropDownList ID="ProductoCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ProductoCategoria_SelectedIndexChanged" ></asp:DropDownList>
                </td>
            </tr>

            <tr>
               <td>Marcas:</td><td>
                <asp:DropDownList ID="ProductoMarca" runat="server" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Estado:</td>
                <td><asp:DropDownList ID="Estado" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
            </tr>

            <tr>
               <td>
                   &nbsp;</td><td><asp:Button ID="BotonGuardar" runat="server" Text="Guardar" OnClick="BotonGuardar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
           
        </table>
      </div>


</asp:Content>
